using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Business
{
    public class SelectionAlreadyExistException : Exception
    {
        public SelectionAlreadyExistException(string message) : base(message) { }
    }

    public class NoItemMarkedException : Exception
    {
        public NoItemMarkedException(string message) : base(message) { }
    }

    public class ParameterMismatchException : Exception
    {
        public ParameterMismatchException(string message) : base(message) { }
    }

    public class NoteTypeNullException : Exception
    {
        public NoteTypeNullException(string message) : base(message) { }
    }

    public class PriceListAlreadyExistException : Exception
    {
        public PriceListAlreadyExistException(string message) : base(message) { }
    }

     public class CannotEraseFromPriceListException : Exception
    {
         public CannotEraseFromPriceListException(string message) : base(message) { }
    }

    public class CannotApproveRejectPriceListItemsException : Exception
    {
        public CannotApproveRejectPriceListItemsException(string message) : base(message) { }
    }

    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message) : base(message) { }
    }

    public class EmptyImportationFileException : Exception
    {
        public EmptyImportationFileException(string message) : base(message) { }
    }

}
