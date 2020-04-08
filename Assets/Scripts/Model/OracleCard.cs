﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using deckmaster;
using Color = deckmaster.Color;

[Serializable]
public class OracleCard
{
    public string[] colorIdentity;
    public string name;
    public string[] superTypes;

    [IgnoreDataMember]
    
    public Color ColorIdentity
    {
        get
        {
            Color result = Color.Colorless;
            foreach (string colorString in colorIdentity)
            {
                Color temp;
                if (Enum.TryParse(colorString, out temp))
                {
                    result |= temp;
                    result &= ~Color.Colorless;
                }

            }

            return result;
        }
    }

    public SuperTypes SuperTypes
    {
        get
        {
            SuperTypes result = SuperTypes.Undefined;
            foreach (string superType in superTypes)
            {
                SuperTypes temp;
                if (Enum.TryParse(superType, out temp))
                {
                    result |= temp;
                    result &= ~SuperTypes.Undefined;
                }
            }

            return result;
        }
    }
}
