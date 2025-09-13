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
    /// 培训
    /// </summary>
	[Table("Trainings")]

    [Display(Name = "培训")]
    public class Training : TopBasePoco
    {
        [Display(Name = "部门")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DepartmentEnum Department { get; set; }
        [Display(Name = "工号")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string JobNo { get; set; }
        [Display(Name = "姓名")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Name { get; set; }

        [Display(Name = "职称1")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum Title1 { get; set; }

        [Display(Name = "职称2")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum2 Title2 { get; set; }

        [Display(Name = "培训项目")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string TrainName { get; set; }
        [Display(Name = "学时")]
        [Range(1,999999999,ErrorMessage="Validate.{0}range{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public int? TeachingTime { get; set; }
        [Display(Name = "开始时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "结束时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "培训单位")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string TrainingUnit { get; set; }
        [Display(Name = "佐证材料扫描件")]
        public List<TrainingEvidence> Evidence { get; set; }

        [Display(Name = "审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examin { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }

	}
    public class TrainingEvidence : TopBasePoco, ISubFile
    {
        public Guid TrainingId { get; set; }
        public Training Training { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
