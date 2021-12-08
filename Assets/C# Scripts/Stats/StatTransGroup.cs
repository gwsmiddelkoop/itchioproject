using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTransGroup
{
    public Dictionary<StatTypes, List<StatTransBase>> stats = new Dictionary<StatTypes, List<StatTransBase>>();

    public StatTransGroup()
    {
        for (int i = 0; i < System.Enum.GetNames(typeof(StatTypes)).Length + 1; i++)
        {
            stats.Add((StatTypes)i, new List<StatTransBase>());
        }       
    }

    public StatTransGroup(List<StatTransBase> statList)
    {
        AddStatsFromStatList(statList);
    }

    public void AddStatsFromStatList(List<StatTransBase> statList)
    {
        if (stats == null)
        {
            stats = new Dictionary<StatTypes, List<StatTransBase>>();
        }

        for (int i = 0; i < System.Enum.GetNames(typeof(StatTypes)).Length; i++)
        {
            StatTypes currentStatType = (StatTypes)i;

            if (!stats.ContainsKey(currentStatType))
            {
                stats.Add(currentStatType, new List<StatTransBase>());
            }
        }

        for (int i = 0; i < statList.Count; i++)
        {
            stats[statList[i].statType].Add(statList[i]);
        }
    }

    public StatGroup TransformStatGroup()
    {
        StatGroup statGroup = new StatGroup();

        for (int curStatTypeInt = 0; curStatTypeInt < System.Enum.GetNames(typeof(StatTypes)).Length; curStatTypeInt++)
        {
            List<StatTransBase> curList = stats[(StatTypes)curStatTypeInt];

            for (int curStatIndex = 0; curStatIndex < curList.Count; curStatIndex++)
            {
                statGroup = curList[curStatIndex].TransformStat(statGroup);
            }
        }

        return statGroup;
    }
}

public class StatTransGroupConverter
{
    public StatTransGroup Convert(List<StatTransGroupTemplate> templates)
    {
        StatTransGroup statTransGroup = new StatTransGroup();

        for (int templateIndex = 0; templateIndex < templates.Count; templateIndex++)
        {
            statTransGroup.AddStatsFromStatList(templates[templateIndex].statTransGroup);
        }

        return statTransGroup;
    }

    public StatTransGroup Convert(StatTransGroupTemplate template)
    {
        return new StatTransGroup(template.statTransGroup);
    }

    public StatTransGroup Convert(List<StatTransBase> statTransBases)
    {
        return new StatTransGroup(statTransBases);
    }
}