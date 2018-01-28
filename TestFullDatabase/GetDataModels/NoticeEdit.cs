using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.GetDataModels
{
    public class NoticeEdit
    {
       
        public int NoticeId { get; set; }
       
        public string Topic { get; set; }
       
        public string Content { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public bool StudentView { get; set; } 
        public bool TeacherView { get; set; } 
        public bool ParentView { get; set; } 

        public bool Expire { get; set; }
    }
}
