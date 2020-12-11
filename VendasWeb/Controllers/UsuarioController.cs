using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Create([Bind("Email,Senha,Id,CriadoEm,ConfirmacaoSenha,Cep,Logradouro,Uf,Bairro,Localidade")] UsuarioLogado usuarioLogado)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    UserName = usuarioLogado.Email,
                    Email = usuarioLogado.Email,
                    Cep = usuarioLogado.Cep,
                    Localidade = usuarioLogado.Localidade,
                    Logradouro = usuarioLogado.Logradouro,
                    Uf = usuarioLogado.Uf,
                    Bairro = usuarioLogado.Bairro,
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email, Senha")] UsuarioLogado usuarioLogado)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogado.Email, usuarioLogado.Senha, false, false);

            var name = User.Identity.Name;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "Login ou senha inválidos!");
            return View(usuarioLogado);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
