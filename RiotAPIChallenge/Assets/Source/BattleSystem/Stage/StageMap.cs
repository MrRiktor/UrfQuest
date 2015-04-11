using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class StageMap
{
    #region Constants

    private static string StageMapPath = "/Resources/Stages/StageMap.xml";

    #endregion

    #region Private Member Variables

    private Stage[] stages;

    #endregion

    #region Accessors/Modifiers

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

    public StageMap()
    {

    }

    #endregion

    #region Public Methods

    public void Initialize()
    {
        this.FromXML();
    }

    #endregion

    #region Private Methods

    private void FromXML()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(StageMap));
        TextReader textReader = new StreamReader(Application.dataPath + StageMapPath);

        StageMap stageMap = new StageMap();
        stageMap = (StageMap)deserializer.Deserialize(textReader);
        textReader.Close();

        this.stages = stageMap.Stages;
    }

    #endregion
}
