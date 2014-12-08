using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Model {
    public class NoteRepository : INoteRepository {
        public void Add(Note note) {
            using (var context = new BWXEntities()) {
                context.Note.Add(note);

                context.SaveChanges();
            }
        }

        public void Delete(Note note) {
            throw new NotImplementedException();
        }

        public void Update(Note note) {
            throw new NotImplementedException();
        }

        public ICollection<Note> GetAll() {
            using (var context= new BWXEntities()) {
                return context.Note.ToList();
            }
        }

        public Note Get(int id) {
            throw new NotImplementedException();
        }
    }
}