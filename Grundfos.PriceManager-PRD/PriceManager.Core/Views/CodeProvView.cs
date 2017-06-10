using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class CodeProvView
    {
        private string codeGrundfos;
        private int productId;
        private string codeProvider;
        private int providerId;

        public virtual string CodeGrundfos
        {
            get { return codeGrundfos; }
            set { codeGrundfos = value; }
        }

        public virtual int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public virtual int ProviderId
        {
            get { return providerId; }
            set { providerId = value; }
        }

        public virtual string CodeProvider
        {
            get { return codeProvider; }
            set { codeProvider = value; }
        }

        public CodeProvView() {}

        public CodeProvView(int productId, string codeGrundfos, int providerId, string codeProvider)
        {
            this.productId = productId;
            this.codeGrundfos = codeGrundfos;
            this.providerId = providerId;
            this.codeProvider = codeProvider;
        }
    }
}
