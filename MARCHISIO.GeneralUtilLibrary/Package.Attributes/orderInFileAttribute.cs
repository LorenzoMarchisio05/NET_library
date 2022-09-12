using System;

namespace Marchisio.GeneralUtilsLibrary
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field )]   
    public class orderInFileAttribute : Attribute
    {
        public int order { get; }

        public orderInFileAttribute(int order)
        {
            this.order = order;
        }

    }


}

