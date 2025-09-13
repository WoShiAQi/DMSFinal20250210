using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
using System.Text.Json.Serialization;
using DMSFinal.Model;

namespace DMSFinal.Model.BasicData
{
    /// <summary>
    /// 系部荣誉
    /// </summary>
	[Table("DepartmentHonors")]

    [Display(Name = "系部荣誉")]
    public class DepartmentHonor : TopBasePoco
    {
        [Display(Name = "系部")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public DepartmentEnum Department { get; set; }

        [Display(Name = "项目名称（荣誉平台基地等）")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string ProjectName { get; set; }

        [Display(Name = "授奖单位")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string AwardingUnit { get; set; }

        [Display(Name = "获奖等级")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public SubjectEnum AwardLevel { get; set; }

        [Display(Name = "获奖时间")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? RewardTime { get; set; }

        [Display(Name = "批文号")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string AwardNo { get; set; }                 

        [Display(Name = "佐证材料扫描件")]        
        public List<DepartmentHonorEvidence> Evidence { get; set; }


        [Display(Name = "审核")]
        //[Comment("审核")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        //[Comment("不通过原因")]
        public string Reason { get; set; }

	}
    public class DepartmentHonorEvidence : TopBasePoco, ISubFile
    {
        public Guid DepartmentHonorId { get; set; }
        public DepartmentHonor DepartmentHonor { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
