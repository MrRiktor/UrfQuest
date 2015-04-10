using System;

public class RiotImage
{
    #region Constant Property Names

    public static class PropertyNames
    {
        public static readonly String Full = "full";
        public static readonly String Group = "group";
        public static readonly String Sprite = "sprite";
        public static readonly String Height = "h";
        public static readonly String Width = "w";
        public static readonly String X = "x";
        public static readonly String Y = "y";        
    }

    #endregion

    #region Private Member Variables

    /// <summary>
    /// Full picture file name. Ex. Karthus.png (this can be used to find icons from datadragon 
    /// but champion portraits need a "_0" ( Karthus_0.png ) between the champion name and the file type.
    /// </summary>
    private string full;
    
    /// <summary>
    /// ??? I assume this is the group of sprites it belongs to.
    /// </summary>
    private string group;
    
    /// <summary>
    /// Height of the icon in the sprite sheet(usually 48 x 48)
    /// </summary>
    private int height;
    
    /// <summary>
    /// The sprite sheet name this champions icon is contained it. ( Ex. champion1.png )
    /// </summary>
    private string sprite;

    /// <summary>
    /// Width of the icon in the sprite sheet ( usually 48x48 )
    /// </summary>
    private int width;
    
    /// <summary>
    /// X location in a grid of champions sprite sheet. (in pixels)
    /// </summary>
    private int x;

    /// <summary>
    /// Y location in a grid of champions sprite sheet. ( in pixels )
    /// </summary>
    private int y;

    /// <summary>
    /// The actual icon image pulled from Data Dragon
    /// </summary>
    private UnityEngine.Sprite icon;

    /// <summary>
    /// The actual portrait image pulled from Data Dragon
    /// </summary>
    private UnityEngine.Sprite portrait;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Full picture file name. Ex. Karthus.png (this can be used to find icons from datadragon 
    /// but champion portraits need a "_0" ( Karthus_0.png ) between the champion name and the file type.
    /// </summary>
    public string Full
    {
        get
        {
            return full;
        }

        set
        {
            full = value;
        }
    }

    /// <summary>
    /// ??? I assume this is the group of sprites it belongs to.
    /// </summary>
    public string Group
    {
        get
        {
            return group;
        }

        set
        {
            group = value;
        }
    }

    /// <summary>
    /// Height of the icon in the sprite sheet(usually 48 x 48)
    /// </summary>
    public int Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
        }
    }

    /// <summary>
    /// The sprite sheet name this champions icon is contained it. ( Ex. champion1.png )
    /// </summary>
    public string Sprite
    {
        get
        {
            return sprite;
        }

        set
        {
            sprite = value;
        }
    }

    /// <summary>
    /// Width of the icon in the sprite sheet ( usually 48x48 )
    /// </summary>
    public int Width
    {
        get
        {
            return width;
        }

        set
        {
            width = value;
        }
    }

    /// <summary>
    /// X location in a grid of champions sprite sheet. (in pixels)
    /// </summary>
    public int X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    /// <summary>
    /// Y location in a grid of champions sprite sheet. ( in pixels )
    /// </summary>
    public int Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
    }

    /// <summary>
    /// The actual icon image pulled from Data Dragon
    /// </summary>
    public UnityEngine.Sprite Icon
    {
        get
        {
            return this.icon;
        }
        set
        {
            icon = value;
        }
    }

    /// <summary>
    /// The actual portrait image pulled from Data Dragon
    /// </summary>
    public UnityEngine.Sprite Portrait
    {
        get
        {
            return this.portrait;
        }
        set
        {
            portrait = value;
        }
    }

    #endregion
}

