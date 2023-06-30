using GameServerApp;
using Microsoft.AspNetCore.Mvc;
using GameServerApp.Services;
using SharedLibrary;
using Microsoft.AspNetCore.Authorization;

namespace GameServerApp.Controllers;
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;
        private readonly GameDbContext _context;
        public HeroController(IHeroService heroService, GameDbContext context) {
            _heroService = heroService;
            _context = context;

            // _context.Add(user);
            // _context.SaveChanges();
        }
        [HttpGet()]
        // public List<string?> Get([FromRoute] int id) {
        public List<string?> Get() {
            var userId = int.Parse(User.FindFirst("id").Value);
            List<string?> heroList = _context.Hero.Where(u=>u.User.Id == userId).Select(u=>u.Name).ToList();

            _heroService.DoSomething();

            return heroList;
        }

        [HttpPost]
        public Hero Post(CreateHeroRequest request) {

            var userId = int.Parse(User.FindFirst("id").Value);

            var user = _context.Users.First(u=>u.Id == userId);

            var hero = new Hero() {
                Name = request.Name,
                User = user
            };

            _context.Add(hero);
            _context.SaveChanges();

            return hero;
        }
    }

