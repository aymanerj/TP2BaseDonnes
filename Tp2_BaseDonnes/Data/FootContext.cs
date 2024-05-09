using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tp2_BaseDonnes.Models;

namespace Tp2_BaseDonnes.Data
{
    public partial class FootContext : DbContext
    {
        public FootContext()
        {
        }

        public FootContext(DbContextOptions<FootContext> options)
            : base(options)
        {
        }

        public virtual DbSet<But> Buts { get; set; } = null!;
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<ContratEntraineur> ContratEntraineurs { get; set; } = null!;
        public virtual DbSet<ContratJoueur> ContratJoueurs { get; set; } = null!;
        public virtual DbSet<CouleurDequipe> CouleurDequipes { get; set; } = null!;
        public virtual DbSet<Entraineur> Entraineurs { get; set; } = null!;
        public virtual DbSet<Equipe> Equipes { get; set; } = null!;
        public virtual DbSet<GardienBut> GardienButs { get; set; } = null!;
        public virtual DbSet<Joueur> Joueurs { get; set; } = null!;
        public virtual DbSet<Match1> Match1s { get; set; } = null!;
        public virtual DbSet<VueStatistiquesJoueur> VueStatistiquesJoueurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BdFoot");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<But>(entity =>
            {
                entity.HasOne(d => d.Joueur)
                    .WithMany(p => p.Buts)
                    .HasForeignKey(d => d.JoueurId)
                    .HasConstraintName("FK_But_JoueurId");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Buts)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_But_MatchId");
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ContratEntraineur>(entity =>
            {
                entity.HasOne(d => d.Entraineur)
                    .WithMany(p => p.ContratEntraineurs)
                    .HasForeignKey(d => d.EntraineurId)
                    .HasConstraintName("FK_ContratEntraineur_EntraineurId");

                entity.HasOne(d => d.Equipe)
                    .WithMany(p => p.ContratEntraineurs)
                    .HasForeignKey(d => d.EquipeId)
                    .HasConstraintName("FK_ContratEntraineur_EquipeId");
            });

            modelBuilder.Entity<ContratJoueur>(entity =>
            {
                entity.HasOne(d => d.Equipe)
                    .WithMany(p => p.ContratJoueurs)
                    .HasForeignKey(d => d.EquipeId)
                    .HasConstraintName("FK_ContratJoueur_EquipeId");

                entity.HasOne(d => d.Joueur)
                    .WithMany(p => p.ContratJoueurs)
                    .HasForeignKey(d => d.JoueurId)
                    .HasConstraintName("FK_ContratJoueur_JoueurId");
            });

            modelBuilder.Entity<GardienBut>(entity =>
            {
                entity.Property(e => e.ButEncaisse).HasDefaultValueSql("((0))");

                entity.Property(e => e.CleanSheet).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Joueur)
                    .WithMany(p => p.GardienButs)
                    .HasForeignKey(d => d.JoueurId)
                    .HasConstraintName("FK_GardienBut_JoueurId");
            });

            modelBuilder.Entity<Match1>(entity =>
            {
                entity.HasKey(e => e.MatchId)
                    .HasName("PK_Match_MatchId");

                entity.HasOne(d => d.Equipe)
                    .WithMany(p => p.Match1s)
                    .HasForeignKey(d => d.EquipeId)
                    .HasConstraintName("FK_Match1_EquipeId");
            });

            modelBuilder.Entity<VueStatistiquesJoueur>(entity =>
            {
                entity.ToView("VueStatistiquesJoueurs");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
