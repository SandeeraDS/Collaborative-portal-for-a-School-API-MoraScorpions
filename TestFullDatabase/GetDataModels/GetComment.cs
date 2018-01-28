using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.GetDataModels
{
    public class GetComment
    {

       
        public int CommentId { get; set; }   
        public string Content { get; set; }   
        public DateTime CommentedTime { get; set; }
        public int NoteID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PicUrl { get; set; }
           
    


    }
}
