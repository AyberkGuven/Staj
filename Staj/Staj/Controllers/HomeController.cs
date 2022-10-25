using Staj.Context;
using Staj.Models;
using Staj.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Staj.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            using (var db = new BizimDbContext())
            {
                var data = (from b in db.Bizims
                            join c in db.Cores
                            on b.coreId equals c.Id
                            join d in db.DCs
                            on b.dcKabloId equals d.Id
                            join s in db.Sokaks
                            on b.sokakAdiId equals s.Id
                            join t in db.Tups
                            on b.tupId equals t.Id
                            join sp in db.Sipliters
                            on b.sipliterAdiId equals sp.Id
                            select new BizimViewModel()
                            {
                                Id = b.Id,
                                tupId = t.Name,
                                coreId = c.Name,
                                coreSirasi = b.coreSirasi,
                                dcKabloId = d.Name,
                                sokakAdiId = s.Name,
                                binaAdi = b.binaAdi,
                                Blok = b.Blok,
                                aktifKullanici = b.aktifKullanici,
                                sipliterAdiId = sp.Name,
                                coreKdSayisi = b.coreKdSayisi
                            }).ToList();
                return View(data);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            using (var db = new BizimDbContext())
            {
                CreateDataViewModel data = new CreateDataViewModel();
                data.CoreListViewModels = db.Cores.Select(
                    c => new CoreListViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
                data.DcListViewModels = db.DCs.Select(
                    dc => new DcListViewModel()
                    {
                        Id = dc.Id,
                        Name = dc.Name
                    }).ToList();
                data.SokakListViewModels = db.Sokaks.Select(
                    s => new SokakListViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList();
                data.SipliterListViewModels = db.Sipliters.Select(
                    sp => new SipliterListViewModel()
                    {
                        Id = sp.Id,
                        Name = sp.Name
                    }).ToList();
                data.TupListViewModels = db.Tups.Select(
                    t => new TupListViewModel()
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList();
                return View(data);
            }
        }

        [HttpPost]
        public ActionResult Create(CreateDataViewModel mgData)
        {
            using (var db = new BizimDbContext())
            {
                Bizim Bizims = new Bizim();
                Bizims.tupId = mgData.CreateViewModels.tupId;
                Bizims.coreId = mgData.CreateViewModels.coreId;
                Bizims.coreSirasi = mgData.CreateViewModels.coreSirasi;
                Bizims.dcKabloId = mgData.CreateViewModels.dcKabloId;
                Bizims.sokakAdiId = mgData.CreateViewModels.sokakAdiId;
                Bizims.binaAdi = mgData.CreateViewModels.binaAdi;
                Bizims.Blok = mgData.CreateViewModels.Blok;
                Bizims.aktifKullanici = mgData.CreateViewModels.aktifKullanici;
                Bizims.sipliterAdiId = mgData.CreateViewModels.sipliterAdiId;
                Bizims.coreKdSayisi = mgData.CreateViewModels.coreKdSayisi;
                db.Bizims.Add(Bizims);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            using (var db = new BizimDbContext())
            {

                EditDataViewModel editV = new EditDataViewModel();
                editV.EditViewModels = db.Bizims.Where(e => e.Id == id).Select(e => new EditViewModel()
                {
                    Id = e.Id,
                    coreId = e.coreId,
                    coreSirasi = e.coreSirasi,
                    dcKabloId = e.dcKabloId,
                    sokakAdiId = e.sokakAdiId,
                    binaAdi = e.binaAdi,
                    Blok = e.Blok,
                    aktifKullanici = e.aktifKullanici,
                    sipliterAdiId = e.sipliterAdiId,
                    coreKdSayisi = e.coreKdSayisi
                }).FirstOrDefault();
                editV.CoreListViewModels = db.Cores.Select(c => new CoreListViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
                editV.DcListViewModels = db.DCs.Select(dc => new DcListViewModel()
                {
                    Id = dc.Id,
                    Name = dc.Name
                }).ToList();
                editV.SokakListViewModels = db.Sokaks.Select(s => new SokakListViewModel()
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
                editV.SipliterListViewModels = db.Sipliters.Select(sp => new SipliterListViewModel()
                {
                    Id = sp.Id,
                    Name = sp.Name
                }).ToList();
                editV.TupListViewModels = db.Tups.Select(t => new TupListViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList();
                return View(editV);

            }

        }

        [HttpPost]
        public ActionResult Edit(EditDataViewModel mgData, int id)
        {
            using (var db = new BizimDbContext())
            {
                var edit = db.Bizims.Find(id);
                edit.tupId = mgData.EditViewModels.tupId;
                edit.coreId = mgData.EditViewModels.coreId;
                edit.coreSirasi = mgData.EditViewModels.coreSirasi;
                edit.sokakAdiId = mgData.EditViewModels.sokakAdiId;
                edit.binaAdi = mgData.EditViewModels.binaAdi;
                edit.Blok = mgData.EditViewModels.Blok;
                edit.aktifKullanici = mgData.EditViewModels.aktifKullanici;
                edit.sipliterAdiId = mgData.EditViewModels.sipliterAdiId;
                edit.coreKdSayisi = mgData.EditViewModels.coreKdSayisi;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            using (var db = new BizimDbContext())
            {
                var Bizim = db.Bizims.Find(id);
                db.Bizims.Remove(Bizim);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}