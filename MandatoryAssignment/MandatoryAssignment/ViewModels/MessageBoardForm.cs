using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MandatoryAssignment.ViewModels
{
    public class MessageBoardForm
    {
        [Required]
        public int MemberID { get; set; }

        [Required]
        public string Message { get; set; }
    }
}