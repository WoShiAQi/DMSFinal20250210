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
    /// 教师参赛
    /// </summary>
	[Table("TeacherCompetitions")]

    [Display(Name = "教师参赛")]
    public class TeacherCompetition : TopBasePoco
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

        [Display(Name = "大赛名称")]
        [StringLength(30, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string CompetitionName { get; set; }
        [Display(Name = "获奖等级")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public AwardLevelEnum RewardLevel { get; set; }
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
        [Display(Name = "排名")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public RankEnum Rank { get; set; }
        [Display(Name = "佐证材料扫描件")]
        public List<TeacherCompetitionEvidence> Evidence { get; set; }

        [Display(Name = "审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }

	}
    public class TeacherCompetitionEvidence : TopBasePoco, ISubFile
    {
        public Guid TeacherCompetitionId { get; set; }
        public TeacherCompetition TeacherCompetition { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
