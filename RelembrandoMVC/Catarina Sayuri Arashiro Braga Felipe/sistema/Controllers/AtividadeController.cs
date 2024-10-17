using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using sistema.Contexts;
using sistema.Models;

namespace sistema.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly SistemaContext _context;

        public AtividadeController(SistemaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int turmaId)
        {
            var atividades = _context.Atividades
                .Include(a => a.Turma)
                .Where(a => a.TurmaId == turmaId);

            var turma = _context.Turmas.FirstOrDefault(x => x.TurmaId == turmaId);

            ViewBag.TurmaId = turmaId;
            ViewBag.NomeTurma = turma!.Nome;

            ViewBag.NomeProfessor = HttpContext.Session.GetString("Nome");

            return View(atividades);

        }

        [HttpPost]
        public IActionResult CadastrarAtividade(int turmaId, string descricao)
        {
            var turma = _context.Turmas.FirstOrDefault(t => t.TurmaId == turmaId);

            if (turma == null)
            {
                return View();
            }

            var novaAtividade = new Atividade
            {
                Descricao = descricao,
                TurmaId = turmaId
            };

            _context.Atividades.Add(novaAtividade);

            _context.SaveChanges();

            return RedirectToAction("Index", "Atividades", new {turmaId});
        }

    }
}
