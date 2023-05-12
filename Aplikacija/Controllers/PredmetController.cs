using Microsoft.AspNetCore.Mvc;

namespace Aplikacija.Controllers;

[ApiController]
[Authorize]
[Route("/predmeti")]
public class PredmetController : ControllerBase{

    public IzaberryMeDbContext Context { get; set; }

    public PredmetController(IzaberryMeDbContext context)
    {
        Context = context;
    }

   [HttpPost("dodajPredmet")]
   public async Task<ActionResult> dodajPredmet([FromBody] Predmet predmet)
   {
    try
    {
        Context.Predmeti!.Add(predmet);
        await Context.SaveChangesAsync();
        return Ok("Dodali smo predmet sa id-jem"+predmet.Id);
    }
    catch(Exception e)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
    }
   }
   [HttpPut("dodajOcenu/{predmetId}")]
   public async Task<ActionResult> dodajOcenu(int predmetId, [FromBody]Ocena ocena) {
    try {
        var predmet = await Context.Predmeti.FindAsync(predmetId);
        if(predmet == null) {
            return NotFound("Predmet sa zadatim id-jem nije pronadjen");
        }
        Context.Ocene.Add(ocena);
        await Context.SaveChangesAsync();
        if(predmet.Ocene == null) {
            predmet.Ocene = new List<Ocena>();
        }
        predmet.Ocene.Add(ocena);
        Context.Predmeti.Update(predmet);
        await Context.SaveChangesAsync();
        return Ok(predmet);
    }
    catch(Exception ex){
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    }
   }

   [HttpPut("dodajTag/{predmetId}/{tagName}")]
   public async Task<ActionResult> dodajTag(int predmetId, string tagName){
    try {
        var predmet = await Context.Predmeti.FindAsync(predmetId);
        if(predmet == null) {
            return NotFound("Predmet sa zadatim id-jem nije pronadjen");
        }
        var tag = Context.Tagovi.FirstOrDefault((tag) => tag.Naziv == tagName);
        if(tag == null) {
            return NotFound("Tag nije pronadjen");
        }
        if(predmet.Tagovi == null){
            predmet.Tagovi = new List<Tag>();
            predmet.Tagovi.Add(tag);
        }
        Context.Predmeti.Update(predmet);
        await Context.SaveChangesAsync();
        return Ok(predmet);
    }
    catch(Exception ex){
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    }
   }

   [AllowAnonymous]
   [HttpGet]
   public async Task<ActionResult> vratiPredmet()
   {
    Console.WriteLine($"auth header: {Request.Headers.Authorization}");
    try {
        return Ok(await Context.Predmeti!.Include(predmet => predmet.Ocene).Include(predmet => predmet.Tagovi).ToListAsync());
    }
   catch(Exception e)
   {
    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
   }
   }

   [HttpDelete("obrisi/{id}")]
   public async Task<ActionResult> obrisiPredmet(int id)
   {
       
        var p = await Context.Predmeti!.FindAsync(id);
       
       if(p!= null)
       {
        Context.Predmeti.Remove(p);
         await Context.SaveChangesAsync();
         return Ok("Obrisali smo premet sa rednim brojem" + id);
       }
       else
       {
        return BadRequest("ne postoji trazeni predmet");
       }
      
   }

  
   [AllowAnonymous]
   [HttpGet("pretraziPoNazivu/{naziv}")]
   public async Task<ActionResult> PretraziPoNazivu(string naziv)
   {
       
        var p = await Context.Predmeti.Where(s=> s.Naziv == naziv).ToListAsync();
        
        if(p != null)
        {
           return Ok(p);
        }
        else
        {
           return NotFound("Ne postoji predmet sa trazenim nazivom.");
        }

   }

   [AllowAnonymous]
   [HttpGet("pretrazi/{modul}/{semestar}")]
   public async Task<ActionResult> Pretrazi(string modul, int semestar)
   {
        var p = await Context.Predmeti.Where(s=> s.Modul == modul && s.Semestar == semestar).ToListAsync();
        
        if(p != null)
        {
           return Ok(p);
        }
        else
        {
           return NotFound("Ne postoje takvi predmeti");
        }
   }

   [HttpPut("azurirajOpis/{opis}/{idpredmeta}")]
    public async Task<ActionResult>  AzurirajOpis(string opis, int idpredmeta)
    {
       var novipredmet = await Context.Predmeti.FindAsync(idpredmeta);

       if(novipredmet != null)
       {
           novipredmet.Opis = opis;
           Context.Predmeti.Update(novipredmet);
           await Context.SaveChangesAsync();
           return Ok(novipredmet);

       }
       else
       {
            return NotFound("Ne postoji odrenjeni predmet");
       }
    }

    [HttpPut("azurirajPredmet/{idpredmeta}")]
    public async Task<ActionResult> azurirajPredmet([FromBody] Predmet predmet,int  idpredmeta)
    {
        var stariPredmet = await Context.Predmeti!.FindAsync(idpredmeta);
        if(stariPredmet != null)
        {

            stariPredmet.Naziv = predmet.Naziv;
            stariPredmet.Modul = predmet.Modul;
            stariPredmet.Opis = predmet.Opis;
            stariPredmet.Semestar = predmet.Semestar;
            stariPredmet.Tagovi = predmet.Tagovi;
            stariPredmet.ESPB = predmet.ESPB;
            stariPredmet.Ocene = predmet.Ocene;
            
            Context.Predmeti!.Update(stariPredmet);
            await Context.SaveChangesAsync();
            return Ok("promenili smo stadion" + stariPredmet);
        }
        else 
        {
            return NotFound("Ne postoji trazeni predmet");
        }
       

    }

    [HttpGet("ocenaPredmeta/{idpredmeta}")]
    public async Task<ActionResult> ocenaPredmeta(int idpredmeta)
    {
       
          var ocene = await Context.Predmeti.Where(p=> p.Id == idpredmeta)
                                      .Include(p=> p.Ocene)
                                      .Select(p=>new{
                                        p.Ocene
                                      }).ToListAsync();
                                  
         return Ok(ocene); 
        
    }

    [AllowAnonymous]
    [HttpGet("komentari/{idpredmeta}")]
    public async Task<ActionResult> vratiKomentare(int idpredmeta)
    {
        var komentari = await Context.Komentari.Include(p=>p.Predmet)
                                        .Where(p=>p.Predmet.Id == idpredmeta)
                                        .Select(p=>new{
                                            p.Id,
                                            p.Text
                                        }).ToListAsync();

        return Ok(komentari);
    }
}