using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using System.Web.Security;
using NybbleMembership;


namespace PriceManager.Business
{
    public class NoteController : AbstractNHibernateDao<Note, int>
    {
        public NoteController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        /// <summary>
        /// Creates a Note in the system
        /// </summary>
        /// <param name="type">Type of object</param>
        /// <param name="typeIdentifier">Identifier of the type</param>
        /// <param name="subject"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public Note Create(Type type, int typeIdentifier, string subject, string description)
        {
            Note n = new Note();
            n.TypeName = type.FullName;
            n.TypeIdentifier = typeIdentifier;
            n.Subject = subject;
            n.Description = description;
            Save(n);

            CommitChanges();

            return n;
        }

        /// <summary>
        /// Removes a note from the system
        /// </summary>
        /// <param name="id">Identifier</param>
        public void Remove(int id)
        {
            Note n = GetById(id);
            if (n != null)
                this.Delete(n);

            CommitChanges();
        }

        /// <summary>
        /// Get all the notes for the current type, ordered by creation date.
        /// </summary>
        /// <param name="type">Tipo de objeto a la cual se agrega la nota</param>
        /// <returns>List of notes</returns>
        public IList<Note> ListByType(Type type)
        {
            return ListByType(type, null, false, null);
        }

        /// <summary>
        /// Get all the notes for the current type and current identifier, ordered by creation date.
        /// </summary>
        /// <param name="type">Tipo de objeto a la cual se agrega la nota</param>
        /// <param name="typeIdentifier">Identifier of the type</param>
        /// <returns>List of notes</returns>
        public IList<Note> ListByType(Type type, int typeIdentifier)
        {
            return ListByType(type, typeIdentifier, false, null);
        }

        /// <summary>
        /// Get all the notes for the current type and current identifier, ordered by creation date.
        /// </summary>
        /// <param name="type">Current object type</param>
        /// <param name="typeIdentifier">Identifier of the type</param>
        /// <param name="maxResults">Maximum results to retrieve</param>
        /// <returns>List of notes</returns>
        public IList<Note> ListByType(Type type, int typeIdentifier, int? maxResults)
        {
            return ListByType(type, typeIdentifier, false, maxResults);
        }

        /// <summary>
        /// Get all the notes for the current type, ordered by creation date.
        /// </summary>
        /// <param name="currentUser">If true only returns notes of the current user.</param>
        /// <param name="type">Tipo de objeto a la cual se agrega la nota</param>
        /// <returns>List of notes</returns>
        private IList<Note> ListByType(Type type, int? typeIdentifier, bool currentUser, int? maxResults)
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("TimeStamp.CreatedOn", false));
            crit.Add(Expression.Eq("TypeName", type.FullName));

            if (typeIdentifier.HasValue)
                crit.Add(Expression.Eq("TypeIdentifier", typeIdentifier));

            if (currentUser)
                crit.Add(Expression.Eq("TimeStamp.CreatedBy", MembershipHelper.GetUser().UserId));
            
            if(maxResults.HasValue)
                crit.SetMaxResults(Convert.ToInt32(maxResults));

            return crit.List<Note>();
        }
    }
}