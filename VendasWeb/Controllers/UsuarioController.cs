using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(Context context,
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioLogado.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioLogado = await _context.UsuarioLogado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioLogado == null)
            {
                return NotFound();
            }

            return View(usuarioLogado);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Senha,Id,CriadoEm,ConfirmacaoSenha")] UsuarioLogado usuarioLogado)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    UserName = usuarioLogado.Email,
                    Email = usuarioLogado.Email
                };

                IdentityResult result = await _userManager.CreateAsync(usuario, usuarioLogado.Senha);
                var token = _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                if (result.Succeeded)
                {
                    _context.Add(usuarioLogado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                AdicionarErros(result);
            }
            return View(usuarioLogado);
        }

        public void AdicionarErros(IdentityResult result)
        {
            foreach (IdentityError erro in result.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioLogado = await _context.UsuarioLogado.FindAsync(id);
            if (usuarioLogado == null)
            {
                return NotFound();
            }
            return View(usuarioLogado);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Email,Senha,Id,CriadoEm")] UsuarioLogado usuarioLogado)
        {
            if (id != usuarioLogado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioLogado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioLogadoExists(usuarioLogado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioLogado);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioLogado = await _context.UsuarioLogado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioLogado == null)
            {
                return NotFound();
            }

            return View(usuarioLogado);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioLogado = await _context.UsuarioLogado.FindAsync(id);
            _context.UsuarioLogado.Remove(usuarioLogado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioLogadoExists(int id)
        {
            return _context.UsuarioLogado.Any(e => e.Id == id);
        }
    }
}
