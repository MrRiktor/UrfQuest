#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: Enemy.cs
 * Date Created: 4/11/2015 3:14AM EST
 * 
 * Description: The Enemy data class.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 12:56 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 6:46 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Xml.Serialization;

#endregion

public class Enemy : Being
{
    #region Private Member Variables

    /// <summary>
    /// The id of the party member (0-4).
    /// </summary>
    private int partyMemberId;
    
    /// <summary>
    /// The path to the icon in the Resources folder.
    /// </summary>
    private String iconPath;
    
    /// <summary>
    /// The path to the portrait in the Resources folder.
    /// </summary>
    private String portraitPath;
    
    /// <summary>
    /// The path to the attack sound clip in the Resources folder.
    /// </summary>
    private String soundClipPath;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Accessor/Modifier for the partymemberId member variable
    /// </summary>
    [XmlAttribute("id")]
    public int PartyMemberId
    {
        get
        {
            return this.partyMemberId;
        }
        set
        {
            this.partyMemberId = value;
        }
    }
    
    /// <summary>
    /// Accessor/Modifier for the iconPath member variable.
    /// 
    /// Note: When the setter of this function is called, we load the icon 
    /// sprite from the resources folder and assign it to our inherited Icon variable.
    /// </summary>
    public String IconPath
    {
        get 
        {
            return this.iconPath;
        }
        set 
        {
            this.iconPath = value;

            if (this.Icon == null)
            {
                UnityEngine.Texture2D texture = UnityEngine.Resources.Load(iconPath) as UnityEngine.Texture2D;

                if (texture != null)
                {
                    this.Icon = UnityEngine.Sprite.Create(texture, new UnityEngine.Rect(0f, 0f, texture.width, texture.height), new UnityEngine.Vector2(0.5f, 0.5f), 128f);
                }
            }
        }
    }

    /// <summary>
    /// Accessor/Modifier for the portraitPath member variable.
    /// 
    /// Note: When the setter of this function is called, we load the portrait 
    /// sprite from the resources folder and assign it to our inherited Portrait variable.
    /// </summary>
    public String PortraitPath
    {
        get 
        { 
            return this.portraitPath; 
        }
        set 
        {
            this.portraitPath = value; 
         
            if(this.Portrait == null)
            {
                UnityEngine.Texture2D texture = UnityEngine.Resources.Load(portraitPath) as UnityEngine.Texture2D;
                
                if (texture != null)
                {
                    this.Portrait = UnityEngine.Sprite.Create(texture, new UnityEngine.Rect(0f, 0f, texture.width, texture.height), new UnityEngine.Vector2(0.5f, 0.5f), 128f); ;
                }
            }
        }
    }

    /// <summary>
    /// Accessor/Modifier for the soundClipPath member variable.
    /// 
    /// Note: When the setter of this function is called, we load the soundClipPath 
    /// AudioClip from the resources folder and assign it to our inherited AttackClip variable.
    /// </summary>
    public String SoundClipPath
    {
        get
        {
            return this.soundClipPath;
        }
        set
        {
            this.soundClipPath = value;
            
            if (this.AttackClip == null)
            {
                UnityEngine.AudioClip audioClip = UnityEngine.Resources.Load<UnityEngine.AudioClip>(soundClipPath);

                if (audioClip != null)
                {
                    this.AttackClip = audioClip;
                }
            }
        }
    }
    
    #endregion
    
    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Enemy()
    {

    }
    
    #endregion
}
