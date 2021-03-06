﻿using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Students.DataModel.GenericRepository
{
    public class Repository<T> where T : class
    {
        private MongoDatabase _database;
        private string _tableName;
        private MongoCollection<T> _collection;

        // Constructor to initialise database and table/collection
        public Repository(MongoDatabase db, string tableName)
        {
            _database = db;
            _tableName = tableName;
            _collection = _database.GetCollection<T>(tableName);
        }

        ///<summary>
        ///<param name="i"></param>
        ///<returns></returns>
        /// </summary>
        public T Get(int i)
        {
            return _collection.FindOneById(i);
        }

        ///<summary>
        ///Get all records
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            MongoCursor<T> cursor = _collection.FindAll();
            return cursor.AsQueryable<T>();
        }

        ///<summary>
        /// Generic add method to insert entities to collection
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _collection.Insert(entity);
        }

        ///<summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        public void Delete(Expression<Func<T, int>> queryExpression, int id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Remove(query);
        }

        ///<summary>
        /// Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(Expression<Func<T, int>> queryExpression, int id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Update(query, Update<T>.Replace(entity));
        }

    }
}
