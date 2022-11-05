using Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Genes
{
    public class Gene : IEquatable<Gene>
    {
        public GeneType Type {get;set ;}
        public Face SourceFace { get; set; }

        public Gene( GeneType type, Face sourceFace)
        {  
            Type = type;
            SourceFace = sourceFace;
        }

        public bool Equals(Gene other)
        {
            if(ReferenceEquals(null, other)) 
                return false;
            if(ReferenceEquals(this, other)) 
                return true;
            if(Type != other.Type) 
                return false;
            if(!SourceFace.Equals(other.SourceFace)) 
                return false;
            return true;
        }
    }
}
