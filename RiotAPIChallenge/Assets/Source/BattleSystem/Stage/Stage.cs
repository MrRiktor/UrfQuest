using System.Xml.Serialization;
using System;


[Serializable]
public class Stage
{
    [XmlAttribute]
    public int StageNumber
    {
        get; 
        set;
    }

    [XmlElement]
    public string StageImage
    {
        get;
        set;
    }


    [XmlArrayItem("Enemy", typeof(Enemy), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [XmlArray("Enemies", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Enemy[] Enemies
    {
        get;
        set;
    }

    public Stage()
    {

    }

}