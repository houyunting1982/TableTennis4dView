using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Entities.Identity;

namespace TableTennis4dView.Infrastructure.Data.Extensions;

public static class ModelBuilderExtensions
{
    private static long _globalId = 1;
    private static long CurrentId => _globalId++;

    public static void Seed(this ModelBuilder modelBuilder)
    {
        var managementRole = new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Management",
            NormalizedName = "MANAGEMENT".ToUpper()
        };
        var userRole = new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "User",
            NormalizedName = "USER".ToUpper()
        };
        var adminRole = new IdentityRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Admin",
            NormalizedName = "ADMIN".ToUpper()
        };
        modelBuilder.Entity<IdentityRole>()
            .HasData(adminRole, managementRole, userRole);
        var hasher = new PasswordHasher<ApplicationUser>();

        var users = Enumerable.Range(1, 100).Select(index => new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = $"demo{index}",
            NormalizedUserName = $"DEMO{index}",
            Email = $"demo{index}@gmail.com",
            PasswordHash = hasher.HashPassword(null, "demo8888")
        }).ToList();

        modelBuilder.Entity<ApplicationUser>().HasData(users);
        var adminRoleAssigned = false;
        var managementRoleAssigned = false;
        foreach (var user in users)
        {
            if (!adminRoleAssigned)
            {
                modelBuilder.Entity<IdentityUserRole<string>>()
                    .HasData(new IdentityUserRole<string>
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id
                    });
                adminRoleAssigned = true;
            }
            else if (!managementRoleAssigned)
            {
                modelBuilder.Entity<IdentityUserRole<string>>()
                    .HasData(new IdentityUserRole<string>
                    {
                        RoleId = managementRole.Id,
                        UserId = user.Id
                    });
                managementRoleAssigned = true;
            }
            else
            {
                modelBuilder.Entity<IdentityUserRole<string>>()
                    .HasData(new IdentityUserRole<string>
                    {
                        RoleId = userRole.Id,
                        UserId = user.Id
                    });
            }
        }

        var felipe = new Player
        {
            Id = CurrentId,
            FirstName = "Felipe",
            LastName = "Morita",
            Sex = Sex.Male,
            Ownership = Ownership.Official,
            DominantHand = DominantHand.Right,
            InvertedNameOrder = false
        };

        var lupi = new Player
        {
            Id = CurrentId,
            FirstName = "Ilija",
            LastName = "Lupulesku",
            NickName = "Lupi",
            Sex = Sex.Male,
            Ownership = Ownership.Official,
            DominantHand = DominantHand.Right
        };

        var biba = new Player
        {
            Id = CurrentId,
            FirstName = "Biljana",
            LastName = "Golić",
            NickName = "Biba",
            Sex = Sex.Female,
            Ownership = Ownership.Official,
            DominantHand = DominantHand.Right
        };

        modelBuilder.Entity<Player>().HasData(felipe, biba, lupi);
        var felipeLoopOfBlock = new Technique
        {
            Id = CurrentId,
            PlayerId = felipe.Id,
            Title = "Loop Off Block",
            SourcePath = "/players/01-Felipe-Loop-Off-Block.zip"
        };
        var felipeFHCounterLoop = new Technique
        {
            Id = CurrentId,
            PlayerId = felipe.Id,
            Title = "FH Counter Loop",
            SourcePath = "/players/02-Felipe-FH-Counter-Loop.zip"
        };
        var felipeFHCurveOfTS = new Technique
        {
            Id = CurrentId,
            PlayerId = felipe.Id,
            Title = "FH Curve Of TS",
            SourcePath = "/players/03-Felipe-FH-Curve-Off-TS.zip"
        };

        var lupiFHDropShot = new Technique
        {
            Id = CurrentId,
            PlayerId = lupi.Id,
            Title = "FH Drop Shot",
            SourcePath = "/players/20-Lupi-FH-Drop-Shot.zip"
        };
        
        var lupiBHCounterLoop = new Technique
        {
            Id = CurrentId,
            PlayerId = lupi.Id,
            Title = "BH Counter Loop",
            SourcePath = "/players/26-Lupi-BH-Counter-Loop.zip"
        };
        
        var lupiBHInOutOffUS = new Technique
        {
            Id = CurrentId,
            PlayerId = lupi.Id,
            Title = "BH In Out Off US",
            SourcePath = "/players/33-Lupi-BH-In-Out-Off-US.zip"
        };
        
        var lupiBHCounter= new Technique
        {
            Id = CurrentId,
            PlayerId = lupi.Id,
            Title = "BH Counter",
            SourcePath = "/players/35-Lupi-BH-Counter.zip"
        };

        var bibaFHCounterLoop = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "FH Counter Loop",
            SourcePath = "/players/02-Biba-FH-Counter-Loop.zip"
        };

        var bibaBHHighArc = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "BH High Arc",
            SourcePath = "/players/31-Biba-BH-High-Arc.zip"
        };

        var bibaBHLoopOffPush = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "BH Smash High Ball",
            SourcePath = "/players/29-Biba-BH-Loop-Off-Push.zip"
        };
        
        var bibaBHStrawberry = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "BH Strawberry",
            SourcePath = "/players/50-Biba-BH-Strawberry.zip"
        };
        
        var bibaFHTSServe = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "FH TS Serve",
            SourcePath = "/players/57-Biba-FH-TS-Serve.zip"
        };
        
        var bibaBHTSServe = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "BH TS Serve",
            SourcePath = "/players/58-Biba-BH-TS-Serve.zip"
        };
        
        var bibaBHTomahawk = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "BH Tomaawk",
            SourcePath = "/players/59-Biba-BH-Tomahawk.zip"
        };
        
        var bibaFHTomahawk = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "FH Tomahawk",
            SourcePath = "/players/59-Biba-FH-Tomahawk.zip"
        };
        
        var bibaReadyPosition = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "Ready Position",
            SourcePath = "/players/60-Biba-Ready-Position.zip"
        };
        
        var bibaOneStep = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "One Step",
            SourcePath = "/players/61-Biba-One-Step.zip"
        };
        
        var bibaTun = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "Turn",
            SourcePath = "/players/62-Biba-Turn.zip"
        };
        
        var bibaRecoverFromServe = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "Recover From Serve",
            SourcePath = "/players/63-Biba-Recover-From-Serve.zip"
        };
        
        var bibaCrossStep = new Technique
        {
            Id = CurrentId,
            PlayerId = biba.Id,
            Title = "One Step",
            SourcePath = "/players/64-Biba-Cross-Step.zip"
        };

        modelBuilder.Entity<Technique>()
            .HasData(felipeFHCurveOfTS, felipeLoopOfBlock, felipeFHCounterLoop,
                lupiBHCounter, lupiBHCounterLoop, lupiFHDropShot, lupiBHInOutOffUS,
                bibaFHCounterLoop, bibaBHHighArc, bibaBHLoopOffPush, bibaBHStrawberry, bibaFHTSServe, bibaBHTSServe,
                bibaBHTomahawk, bibaFHTomahawk, bibaOneStep, bibaCrossStep, bibaReadyPosition, bibaTun, bibaRecoverFromServe);
    }
}