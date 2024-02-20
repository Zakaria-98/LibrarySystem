﻿using LibrarySystem.Models;
using LibrarySystem.Repositories;

namespace LibrarySystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Category> Categories { get;  set; }
        public IBaseRepository<Book> Books { get; set; }

        public IBaseRepository<Member> Members { get; set; }
        public IBaseRepository<Order> Orders { get; set; }

        public IBaseRepository<Restoration> Restorations { get; set; }
        public IBaseRepository<Item> Items { get; set; }



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new BaseRepository<Category>(_context);
            Books = new BaseRepository<Book>(_context);
            Members = new BaseRepository<Member>(_context);
            Orders = new BaseRepository<Order>(_context);
            Restorations = new BaseRepository<Restoration>(_context);
            Items = new BaseRepository<Item>(_context);



        }

        public int Complete()
        {
           return _context.SaveChanges();

        }
    }
}
