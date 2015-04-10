using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class MessengerEventTypes
{
    //Game State Machine
    public const String GAME_STATE_CHANGE = "game_state_change";

    //TeamSelect
    public const String TSUI_ADD_PARTY = "tsui_add_party";
    public const String TSUI_PARTY_SELECTED = "tsui_party_selected";
    public const String TSUI_PARTY_MEMBER_SELECTED = "tsui_party_member_selected";
    
}