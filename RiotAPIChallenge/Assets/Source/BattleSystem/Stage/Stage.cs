#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: Stage.cs 
 * Date Created: 4/11/2015 2:50AM EST
 * Changelog: - Modified: Matthew "Riktor" Baker - 4/16/2015 6:40 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System.Xml.Serialization;
using System;

#endregion

[Serializable]
public class Stage
{
    #region Private Variables

    /// <summary>
    /// 
    /// </summary>
    private int stageNumber;

    /// <summary>
    /// 
    /// </summary>
    private string stageStory;

    /// <summary>
    /// 
    /// </summary>
    private string stageImage;

    /// <summary>
    /// 
    /// </summary>
    private Enemy[] enemies;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// XML item that contains the stage number.
    /// </summary>
    [XmlAttribute]
    public int StageNumber
    {
        get
        {
            return this.stageNumber;
        }
        set
        {
            this.stageNumber = value;
        }
    }

    /// <summary>
    /// The story string associated with this stage.
    /// </summary>
    [XmlElement]
    public string StageStory
    {
        get
        {
            return this.stageStory;
        }
        set
        {
            this.stageStory = value;
        }
    }

    /// <summary>
    /// The link to the Resources folder of the up front image displayed on the progression screen.
    /// </summary>
    [XmlElement]
    public string StageImage
    {
        get
        {
            return this.stageImage;
        }
        set
        {
            this.stageImage = value;
        }
    }
    
    /// <summary>
    /// The enemies for this stage.
    /// </summary>
    [XmlArrayItem("Enemy", typeof(Enemy), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [XmlArray("Enemies", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Enemy[] Enemies
    {
        get
        {
            return this.enemies;
        }
        set
        {
            this.enemies = value;
        }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Stage()
    {

    }

    #endregion
}