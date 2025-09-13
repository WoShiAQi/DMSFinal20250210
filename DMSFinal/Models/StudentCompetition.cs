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
    /// 学生大赛
    /// </summary>
	[Table("StudentCompetitions")]

    [Display(Name = "学生大赛")]
    public class StudentCompetition : TopBasePoco
    {
        [Display(Name = "部门")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DepartmentEnum Department { get; set; }
        [Display(Name = "学生姓名")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string StudentName { get; set; }
        [Display(Name = "工号")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string JobNo { get; set; }
        [Display(Name = "指导教师")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string TeacherName { get; set; }
        [Display(Name = "大赛名称")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string CompetitionName { get; set; }
        [Display(Name = "获奖等级")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public AwardLevelEnum AwardLevel { get; set; }
        [Display(Name = "授奖单位")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string AwardingUnit { get; set; }
        [Display(Name = "级别")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public ConpetitonLevelEnum Level { get; set; }
        [Display(Name = "获奖时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? RewardTime { get; set; }
        [Display(Name = "佐证材料扫描件")]
        public List<StudentCompetitionEvidence> Evidence { get; set; }

        [Display(Name = "审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }
	}
    public class StudentCompetitionEvidence : TopBasePoco, ISubFile
    {
        public Guid StudentCompetitionId { get; set; }
        public StudentCompetition StudentCompetition { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
