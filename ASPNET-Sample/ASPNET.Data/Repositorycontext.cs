﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPNET.Data.Interfaces;
using System.Data.Objects;

namespace ASPNET.Data
{
  public  class Repositorycontext:IRepositoryContext
    {
      private const string OBJECT_CONTEXT_KEY = "TestProjectContext";


		public IObjectSet<T> GetObjectSet<T>()
			where T : class
		{
			return ContextManager.GetObjectContext(OBJECT_CONTEXT_KEY).CreateObjectSet<T>();
		}

		/// <summary>
		/// Returns the active object context
		/// </summary>
		public ObjectContext ObjectContext
		{
			get
			{
				return ContextManager.GetObjectContext(OBJECT_CONTEXT_KEY);
			}
		}

		public int SaveChanges()
		{
			return this.ObjectContext.SaveChanges();
		}

		public void Terminate()
		{
			ContextManager.SetRepositoryContext(null, OBJECT_CONTEXT_KEY);
		}
	}

    }

