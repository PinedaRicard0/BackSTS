using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;
using sts_models.POCOS;
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

        public async Task<string> UpdateFieldById(FieldP field)
        {
            Field toUpdateField = await _context.Fields.SingleOrDefaultAsync(f => f.Id == field.Id);
            if (toUpdateField != null)
            {
                toUpdateField.Name = field.Name;
                toUpdateField.Address = field.Address;
                toUpdateField.Description = field.Description;
                await _context.SaveChangesAsync();
                return "updated";
            }
            return "No field";
        }
    }
}
