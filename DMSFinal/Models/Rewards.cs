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
    /// 奖励荣誉
    /// </summary>
	[Table("Rewardss")]

    [Display(Name = "奖励荣誉")]
    public class Rewards : TopBasePoco
    {
        [Display(Name = "部门")]
        //[Comment("部门")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DepartmentEnum Department { get; set; }
        [Display(Name = "姓名")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("姓名")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Name { get; set; }

        [Display(Name = "职称1")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum Title1 { get; set; }

        [Display(Name = "职称2")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum2 Title2 { get; set; }

        [Display(Name = "获奖成果名称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("获奖成果名称")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Topic { get; set; }
        [Display(Name = "获奖名称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("获奖名称")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string RewardName { get; set; }
        [Display(Name = "授奖单位")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("授奖单位")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string AwardingUnit { get; set; }
        [Display(Name = "获奖等级")]
        //[Comment("获奖等级")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public AwardLevelEnum AwardLevel { get; set; }
        [Display(Name = "获奖时间")]
        //[Comment("获奖时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? RewardTime { get; set; }
        [Display(Name = "排名")]
        //[Comment("排名")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public RankEnum Rank { get; set; }
        [Display(Name = "第一是否本校老师")]
        //[Comment("第一是否本校老师")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IfOurSchool { get; set; }
        [Display(Name = "佐证材料扫描件")]
        //[Comment("佐证材料扫描件")]
        public List<RewardsEvidence> Evidence { get; set; }
        [Display(Name = "工号")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("工号")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string JobNo { get; set; }
        [Display(Name = "审核")]
        //[Comment("审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        //[Comment("不通过原因")]
        public string Reason { get; set; }

	}
    public class RewardsEvidence : TopBasePoco, ISubFile
    {
        public Guid RewardsId { get; set; }
        public Rewards Rewards { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
