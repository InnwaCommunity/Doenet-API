

using System.Text;
using System;
namespace training.Models
{
    public class GetClusterListComboResult
    {
        public int ClusterId { get; set; }
        public string ClusterIdval {get;set;} = string.Empty;
        public string ClusterName { get; set; } = string.Empty;
        public bool IsPasswordUse { get; set; }
        public int UserId { get; set; }//id that possess
        public bool Admin { get; set; }
        public bool Commander { get; set; }
        public bool Viewer { get; set; }
        public bool Employee { get; set; }
        public bool Inactive { get; set; }
        public int NumOfMembers {get;set;}
        public DateTime CreateDate { get; set; }
    }
}