#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: StageMap.cs
 * Date Created: 4/11/2015 3:34AM EST
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/13/2015 5:12 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 6:40 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System.Xml.Serialization;
using UnityEngine;

#endregion

public class StageMap
{
    #region Private Member Variables

    /// <summary>
    /// The stage array.
    /// </summary>
    private Stage[] stages;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Accessor/Getter for the stage array. 
    /// </summary>
    [XmlArrayItem("Stage", typeof(Stage), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [XmlArray("Stages", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Stage[] Stages
    {
        get
        {
            return this.stages;
        }
        set
        {
            this.stages = value;
        }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public StageMap()
    {

    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Initializes the stage map from the xml file.
    /// </summary>
    public void Initialize()
    {
        this.FromXML();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Pulls the stage data from an XML file and sets the stages array.
    /// </summary>
    private void FromXML()
    {
        TextAsset textAsset = Resources.Load("Stages/StageMap") as TextAsset;

        using (System.IO.StringReader reader = new System.IO.StringReader(textAsset.text))
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(StageMap));

            StageMap stageMap = new StageMap();
            stageMap = (StageMap)deserializer.Deserialize(reader);
            reader.Close();

            this.stages = stageMap.Stages;
        }
    }

    #endregion
}
