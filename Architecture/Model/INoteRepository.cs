using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Model {
    public interface INoteRepository {
        void Add(Note note);
        void Delete(Note note);
        void Update(Note note);
        ICollection<Note> GetAll();
        Note Get(int id);
    }
}