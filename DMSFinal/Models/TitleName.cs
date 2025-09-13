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
    /// 职称列表
    /// </summary>
	[Table("TitleNames")]

    [Display(Name = "职称列表")]
    public class TitleName : TopBasePoco
    {      
        [Display(Name = "职称")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string TitleList { get; set; }

        [Display(Name = "个人职称")]
        public List<MidTitle> PersonInfos { get; set; }
        //public List<MidAchieve> AchievementTransformations { get; set; }
        //public List<MidAward> Awards { get; set; }
        //public List<MidCourse> Courses { get; set; }
        //public List<MidEnterprise> EnterprisePractices { get; set; }
        //public List<MidHorizontal> HorizontalSubjects { get; set; }
        //public List<MidJiaoYan> JiaoYans { get; set; }
        //public List<MidPaper> Papers { get; set; }
        //public List<MidPatent> PatentSoftnesss { get; set; }
        //public List<MidPublication> Publicationss { get; set; }
        //public List<MidReward> Rewardss { get; set; }
        //public List<MidSTAward> STAwards { get; set; }
        //public List<MidTeacher> TeacherCompetitions { get; set; }
        //public List<MidTraining> Trainings { get; set; }
        //public List<MidVetical> VerticalSubjects { get; set; }
    }    
}
