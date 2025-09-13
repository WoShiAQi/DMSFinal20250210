using System;
using System.ComponentModel.DataAnnotations;

namespace DMSFinal.Model
{
    public enum DepartmentEnum
    {
        [Display(Name = "机电工程系")]
        DMSFinal
    }
    public enum DiplomasEnum
    {
        [Display(Name = "研究生")]
        Yan,
        [Display(Name = "本科")]
        Ben,
        [Display(Name = "高中")]
        Gao,
        [Display(Name = "初中")]
        Chu,
        [Display(Name = "小学")]
        Xiao,
        [Display(Name = "其他")]
        Other
    }
    public enum DegreeEnum
    {
        [Display(Name = "博士")]
        Bo,
        [Display(Name = "硕士")]
        Shuo,
        [Display(Name = "学士")]
        Xue
    }
    public enum TitleEnum
    {
        [Display(Name = "无")]
        noTitle,
        [Display(Name = "正教授")]
        Professor,
        [Display(Name = "副教授")]
        AssociateProfessor,
        [Display(Name = "讲师")]
        Lecturer,
        [Display(Name = "助教")]
        Assistant
       
    }
    public enum TitleEnum2
    {
        [Display(Name = "无")]
        noTitle2,
        [Display(Name = "正高级工程师")]
        ZhengGao,
        [Display(Name = "高级工程师")]
        GaoJi,
        [Display(Name = "工程师")]
        GongChengShi,
        [Display(Name = "助理工程师")]
        AssGong,
        [Display(Name = "技术员")]
        JIshu,
        [Display(Name = "正高级实验师")]
        ZhengGaoShiYan,
        [Display(Name = "高级实验师")]
        GaoShiYan,
        [Display(Name = "实验师")]
        ShiYanShi,
        [Display(Name = "助理实验师")]
        AssShiYan,
        [Display(Name = "实验员")]
        ShiYanYuan
    }
    public enum SubjectEnum
    {
        [Display(Name = "国家一等奖")]
        Guo1,
        [Display(Name = "国家二等奖")]
        Guo2,
        [Display(Name = "国家三等奖")]
        Guo3,
        [Display(Name = "省级一等奖")]
        Sheng1,
        [Display(Name = "省级二等奖")]
        Sheng2,
        [Display(Name = "省级三等奖")]
        Sheng3,
        [Display(Name = "市级一等奖")]
        Shi1,
        [Display(Name = "市级二等奖")]
        Shi2,
        [Display(Name = "市级三等奖")]
        Shi3,
        [Display(Name = "校级一等奖")]
        Xiao1,
        [Display(Name = "校级二等奖")]
        Xiao2,
        [Display(Name = "校级三等奖")]
        Xiao3
    }
    public enum RewardEnum
    {
        [Display(Name = "科技进步奖")]
        Jin,
        [Display(Name = "发明奖")]
        Family
    }
    public enum PoliticalIDEnum
    {
        [Display(Name = "中共党员")]
        Dang,
        [Display(Name = "团员")]
        Tuan,
        [Display(Name = "民族党派")]
        MinZhu,
        [Display(Name = "群众")]
        QunZhong
    }
    public enum PoliticalIDEnum2
    {
        [Display(Name = "中共党员")]
        Dang2,
        [Display(Name = "团员")]
        Tuan2,
        [Display(Name = "民族党派")]
        MinZhu2,
        [Display(Name = "群众")]
        QunZhong2
    }
    public enum IfEnum
    {
        [Display(Name = "是")]
        Yes,
        [Display(Name = "否")]
        No
    }
    public enum CategoryEnum
    {
        [Display(Name = "国际刊物")]
        International,
        [Display(Name = "中文核心期刊")]
        ChineseCore,
        [Display(Name = "国内普通期刊")]
        ChineseRegular
    }
    public enum PatentEnum
    {
        [Display(Name = "发明专利")]
        Invention,
        [Display(Name = "实用新型专利")]
        UtilityModel,
        [Display(Name = "外观设计专利")]
        IndustrialDesign,
        [Display(Name = "软件著作权")]
        Copyrights
    }
    public enum PublicationEnum
    {
        [Display(Name = "非规划教材")]
        NoPlanCompile,
        [Display(Name = "国家级规划教材")]
        NationalPlanCompile,
        [Display(Name = "省级规划教材")]
        ProvincePlanCompile,
        [Display(Name = "行业规划教材")]
        CityPlanCompile,
        [Display(Name = "专著")]
        Textbook,
        [Display(Name = "编著")]
        Monograph,
        [Display(Name = "工具书")]
        References,
        [Display(Name = "参考书")]
        ReferenceBooks,
        [Display(Name = "译著")]
        Translation
    }

    public enum CheckEnum
    {
        [Display(Name = "审核中")]
        Checking,
        [Display(Name = "不通过")]
        NotPass,
        [Display(Name = "通过")]
        Pass
    }

    public enum AwardLevelEnum
    {
        [Display(Name = "国家级")]
        NationalOne,       
        [Display(Name = "省级")]
        ProvinceOne,
        [Display(Name = "校级")]
        SchoolOne
    }

    public enum RankEnum
    {
        [Display(Name = "第一")]
        One,
        [Display(Name = "第二")]
        Two,
        [Display(Name = "第三")]
        Three,
        [Display(Name = "第四")]
        Four,
        [Display(Name = "第五")]
        Five,
        [Display(Name = "第六")]
        Six,
        [Display(Name = "第七")]
        Seven,
        [Display(Name = "第八")]
        Eight,
        [Display(Name = "第九")]
        Nine,
        [Display(Name = "第十")]
        Ten,
        [Display(Name = "其它")]
        Other
    }

     public enum PracticeEnum
    {
        [Display(Name = "暑期实践锻炼")]
        summer,
        [Display(Name = "短期实践锻炼")]
        shortTime,
        [Display(Name = "长期实践锻炼")]
        longTime

    }
    public enum ConpetitonLevelEnum
    {
        [Display(Name = "国家级")]
        national,
        [Display(Name = "省级")]
        province,
        [Display(Name = "市级")]
        city,
        [Display(Name = "校级")]
        school
    }


    public class RefDicNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}