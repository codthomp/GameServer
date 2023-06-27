using System;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using SharedLibrary;

namespace Server.Controllers;
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService) {
            _playerService = playerService;
        }

        [HttpGet("{id}")]
        public Player Get([FromRoute] int id) {
            var player = new Player(){Id = id};

            _playerService.DoSomething();

            return player;
        }

        [HttpPost]
        public Player Post(Player player) {
            Console.WriteLine("Player has been added");
            Console.WriteLine("Id: " + player.Id + "Name: " + player.Name + "Health: " + player.Health);
            return player;
        }
    }

