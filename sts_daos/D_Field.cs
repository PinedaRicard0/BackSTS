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
    public class D_Field : ID_Field
    {
        private readonly DataContext _context;
        public D_Field(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Field>> GetAllFields()
        {
            var fields = await _context.Fields.ToListAsync();
            return fields;
        }

        public async Task<string> SaveField(Field field)
        {
            try
            {
                await _context.Fields.AddAsync(field);
                await _context.SaveChangesAsync();
                return "created";
            }
            catch (Exception e) {
                return "Error";
            }
            
        }
    }
}
