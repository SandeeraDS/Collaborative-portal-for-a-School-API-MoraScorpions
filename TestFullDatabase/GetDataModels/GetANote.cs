using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.GetDataModels
{
    public class GetANote
    {
       
        public int NoteId { get; set; }
        public string NoteUrl { get; set; }
        public string NoteTitle { get; set; }
        public string Description { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool Visibility { get; set; }
        public int TernaryId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherImageUrl { get; set; }
        public string SubjectName { get; set; }

        public List<GetComment> Comments { get; set; }
        


    }
}
