using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sts_daos
{
    public class D_Player : ID_Player
    {
        private readonly DataContext _context;
        public D_Player(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<string> SavePlayer(Player player)
        {
            try
            {
                await _context.Players.AddAsync(player);
                await _context.SaveChangesAsync();
                return "created";
            }
            catch (Exception e) {
                return "failed";
            }
        }

        public async Task<List<Player>> GetTeamPlayers(int teamId) {
            List<Player> res = new List<Player>();
            res = await _context.Players.Where(p => p.TeamId == teamId).ToListAsync();
            return res;
        }

        public async Task<string> UpdatePlayer(Player player) {
            Player toUpdatePlayer = await _context.Players.SingleOrDefaultAsync(p => p.Id == player.Id);
            if (toUpdatePlayer != null)
            {
                toUpdatePlayer.Name = player.Name;
                toUpdatePlayer.NickName = player.NickName;
                toUpdatePlayer.Dorsal = player.Dorsal;
                await _context.SaveChangesAsync();
                return "updated";
            }
            return "No field";
        }
    }
}
