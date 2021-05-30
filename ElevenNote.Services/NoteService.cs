﻿using ElevenNote.Models;
using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevenNote2.WebAPI.Models;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;
        public NoteService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateNode(NoteCreate model)
        {
            var entity = 
                new Note()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Notes.Where(e => e.OwnerId == _userId).Select(e => new NoteListItem
                {
                    NoteId = e.NoteId,
                    Title = e.Title,
                    CreatedUtc = e.CreatedUtc
                });

                return query.ToArray();
            }
        }

    }
}