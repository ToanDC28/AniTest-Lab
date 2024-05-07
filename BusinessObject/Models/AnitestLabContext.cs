using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models;

public partial class AnitestLabContext : DbContext
{
    public AnitestLabContext()
    {
    }

    public AnitestLabContext(DbContextOptions<AnitestLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AnalysisLoginDay> AnalysisLoginDays { get; set; }

    public virtual DbSet<AnalysisLoginMonth> AnalysisLoginMonths { get; set; }

    public virtual DbSet<AnalysisWrongQuest> AnalysisWrongQuests { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackGv> FeedbackGvs { get; set; }

    public virtual DbSet<FileUpload> FileUploads { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Messenger> Messengers { get; set; }

    public virtual DbSet<MessengerSeen> MessengerSeens { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<QuestIncorrectRank> QuestIncorrectRanks { get; set; }

    public virtual DbSet<QuestOfTest> QuestOfTests { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentNotification> StudentNotifications { get; set; }

    public virtual DbSet<StudentTestDetail> StudentTestDetails { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SystemSetting> SystemSettings { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherNotification> TeacherNotifications { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL(ConnectionString());

    private string ConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        return config.GetConnectionString("DefaultConnection");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PRIMARY");

            entity.ToTable("admins");

            entity.HasIndex(e => e.GenderId, "admins_gender_id");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Permission, "n4");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.AdminId)
                .HasColumnType("int(11)")
                .HasColumnName("admin_id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasDefaultValueSql("'''avatar-default.jpg'''")
                .HasColumnName("avatar");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("email");
            entity.Property(e => e.GenderId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("gender_id");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.Permission)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("permission");
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .HasColumnName("username");

            entity.HasOne(d => d.Gender).WithMany(p => p.Admins)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("admins_gender_id");

            entity.HasOne(d => d.PermissionNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.Permission)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("n4");
        });

        modelBuilder.Entity<AnalysisLoginDay>(entity =>
        {
            entity.HasKey(e => e.Time).HasName("PRIMARY");

            entity.ToTable("analysis_login_day");

            entity.HasIndex(e => e.Time, "time").IsUnique();

            entity.Property(e => e.Time)
                .HasColumnType("date")
                .HasColumnName("time");
            entity.Property(e => e.Count)
                .HasColumnType("int(11)")
                .HasColumnName("count");
        });

        modelBuilder.Entity<AnalysisLoginMonth>(entity =>
        {
            entity.HasKey(e => e.Time).HasName("PRIMARY");

            entity.ToTable("analysis_login_month");

            entity.HasIndex(e => e.Time, "time").IsUnique();

            entity.Property(e => e.Time)
                .HasColumnType("date")
                .HasColumnName("time");
            entity.Property(e => e.Count)
                .HasColumnType("int(11)")
                .HasColumnName("count");
        });

        modelBuilder.Entity<AnalysisWrongQuest>(entity =>
        {
            entity.HasKey(e => e.Time).HasName("PRIMARY");

            entity.ToTable("analysis_wrong_quest");

            entity.HasIndex(e => e.Time, "time").IsUnique();

            entity.Property(e => e.Time)
                .HasColumnType("date")
                .HasColumnName("time");
            entity.Property(e => e.Blank).HasColumnName("blank");
            entity.Property(e => e.Correct).HasColumnName("correct");
            entity.Property(e => e.Incorrect).HasColumnName("incorrect");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chats");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ChatContent)
                .HasColumnType("text")
                .HasColumnName("chat_content");
            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("class_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TimeSent)
                .HasColumnType("datetime")
                .HasColumnName("time_sent");
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .HasColumnName("username");

            entity.HasOne(d => d.Class).WithMany(p => p.Chats)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("chat_classes_ibfk_1");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PRIMARY");

            entity.ToTable("classes");

            entity.HasIndex(e => e.ClassName, "class_name").IsUnique();

            entity.HasIndex(e => e.GradeId, "k4");

            entity.HasIndex(e => e.TeacherId, "n7");

            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .HasColumnName("class_name");
            entity.Property(e => e.GradeId)
                .HasColumnType("int(10)")
                .HasColumnName("grade_id");
            entity.Property(e => e.TeacherId)
                .HasColumnType("int(11)")
                .HasColumnName("teacher_id");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classes)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("classes_ibfk_2");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("classes_ibfk_1");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("document");

            entity.HasIndex(e => e.GradeId, "grade_id");

            entity.HasIndex(e => e.SubjectId, "subject_id");

            entity.HasIndex(e => e.TypeId, "type_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DocName)
                .HasColumnType("text")
                .HasColumnName("doc_name");
            entity.Property(e => e.DocPath)
                .HasMaxLength(255)
                .HasColumnName("doc_path");
            entity.Property(e => e.GradeId)
                .HasColumnType("int(11)")
                .HasColumnName("grade_id");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.SubjectId)
                .HasColumnType("int(11)")
                .HasColumnName("subject_id");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");

            entity.HasOne(d => d.Grade).WithMany(p => p.Documents)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("document_ibfk_1");

            entity.HasOne(d => d.Subject).WithMany(p => p.Documents)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("document_subject_1");

            entity.HasOne(d => d.Type).WithMany(p => p.Documents)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("document_type_id_1");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("document_type");

            entity.HasIndex(e => e.TypeId, "type_id").IsUnique();

            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");
            entity.Property(e => e.Detail)
                .HasMaxLength(50)
                .HasColumnName("detail");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback");

            entity.HasIndex(e => e.StudentId, "feedback_student");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("student_id");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("time");

            entity.HasOne(d => d.Student).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("feedback_student");
        });

        modelBuilder.Entity<FeedbackGv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback_gv");

            entity.HasIndex(e => e.TeacherId, "gv_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.TeacherId)
                .HasColumnType("int(11)")
                .HasColumnName("teacher_id");
            entity.Property(e => e.Time)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("time");

            entity.HasOne(d => d.Teacher).WithMany(p => p.FeedbackGvs)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("gv_id");
        });

        modelBuilder.Entity<FileUpload>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("file_upload");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FileName)
                .HasMaxLength(200)
                .HasColumnName("file_name");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("time");
            entity.Property(e => e.Uploader)
                .HasMaxLength(50)
                .HasColumnName("uploader");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PRIMARY");

            entity.ToTable("genders");

            entity.Property(e => e.GenderId)
                .HasColumnType("int(1)")
                .HasColumnName("gender_id");
            entity.Property(e => e.GenderDetail)
                .HasMaxLength(20)
                .HasColumnName("gender_detail");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PRIMARY");

            entity.ToTable("grades");

            entity.Property(e => e.GradeId)
                .HasColumnType("int(11)")
                .HasColumnName("grade_id");
            entity.Property(e => e.Detail)
                .HasMaxLength(30)
                .HasColumnName("detail");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PRIMARY");

            entity.ToTable("levels");

            entity.Property(e => e.LevelId)
                .HasColumnType("int(11)")
                .HasColumnName("level_id");
            entity.Property(e => e.LevelDetail)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("level_detail");
        });

        modelBuilder.Entity<Messenger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("messenger");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("time");
            entity.Property(e => e.Type)
                .HasMaxLength(11)
                .HasDefaultValueSql("'''text'''")
                .HasColumnName("type");
            entity.Property(e => e.UsernameGet)
                .HasMaxLength(50)
                .HasColumnName("username_get");
            entity.Property(e => e.UsernameSend)
                .HasMaxLength(50)
                .HasColumnName("username_send");
        });

        modelBuilder.Entity<MessengerSeen>(entity =>
        {
            entity.HasKey(e => e.SendGet).HasName("PRIMARY");

            entity.ToTable("messenger_seen");

            entity.HasIndex(e => e.SendGet, "send_get").IsUnique();

            entity.Property(e => e.SendGet)
                .HasMaxLength(50)
                .HasColumnName("send_get");
            entity.Property(e => e.Count)
                .HasColumnType("int(11)")
                .HasColumnName("count");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PRIMARY");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId)
                .HasColumnType("int(11)")
                .HasColumnName("notification_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NotificationContent)
                .HasColumnType("text")
                .HasColumnName("notification_content");
            entity.Property(e => e.NotificationTitle)
                .HasColumnType("text")
                .HasColumnName("notification_title");
            entity.Property(e => e.TimeSent)
                .HasColumnType("datetime")
                .HasColumnName("time_sent");
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Permission1).HasName("PRIMARY");

            entity.ToTable("permissions");

            entity.Property(e => e.Permission1)
                .HasColumnType("int(11)")
                .HasColumnName("permission");
            entity.Property(e => e.PermissionDetail)
                .HasMaxLength(20)
                .HasColumnName("permission_detail");
        });

        modelBuilder.Entity<QuestIncorrectRank>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PRIMARY");

            entity.ToTable("quest_incorrect_rank");

            entity.Property(e => e.QuestionId)
                .HasColumnType("int(11)")
                .HasColumnName("question_id");
            entity.Property(e => e.A)
                .HasColumnType("int(11)")
                .HasColumnName("a");
            entity.Property(e => e.B)
                .HasColumnType("int(11)")
                .HasColumnName("b");
            entity.Property(e => e.Blank)
                .HasColumnType("int(11)")
                .HasColumnName("blank");
            entity.Property(e => e.C)
                .HasColumnType("int(11)")
                .HasColumnName("c");
            entity.Property(e => e.Count)
                .HasColumnType("int(11)")
                .HasColumnName("count");
            entity.Property(e => e.D)
                .HasColumnType("int(11)")
                .HasColumnName("d");
            entity.Property(e => e.Ratio)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("ratio");
            entity.Property(e => e.RatioA)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("ratio_a");
            entity.Property(e => e.RatioB)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("ratio_b");
            entity.Property(e => e.RatioC)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("ratio_c");
            entity.Property(e => e.RatioD)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("ratio_d");
            entity.Property(e => e.Total)
                .HasColumnType("int(11)")
                .HasColumnName("total");

            entity.HasOne(d => d.Question).WithOne(p => p.QuestIncorrectRank)
                .HasForeignKey<QuestIncorrectRank>(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("quest_incorrect");
        });

        modelBuilder.Entity<QuestOfTest>(entity =>
        {
            entity.HasKey(e => new { e.TestCode, e.QuestionId }).HasName("PRIMARY");

            entity.ToTable("quest_of_test");

            entity.HasIndex(e => e.QuestionId, "question_id");

            entity.HasIndex(e => e.TestCode, "test_code");

            entity.Property(e => e.TestCode)
                .HasColumnType("int(11)")
                .HasColumnName("test_code");
            entity.Property(e => e.QuestionId)
                .HasColumnType("int(11)")
                .HasColumnName("question_id");
            entity.Property(e => e.Timest)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("timest");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestOfTests)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("quest_of_test_ibfk_1");

            entity.HasOne(d => d.TestCodeNavigation).WithMany(p => p.QuestOfTests)
                .HasForeignKey(d => d.TestCode)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("quest_of_test_ibfk_2");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PRIMARY");

            entity.ToTable("questions");

            entity.HasIndex(e => e.GradeId, "k9");

            entity.HasIndex(e => e.LevelId, "level_id");

            entity.HasIndex(e => e.StatusId, "status_id");

            entity.HasIndex(e => e.SubjectId, "subjects_key");

            entity.HasIndex(e => e.Unit, "unit");

            entity.Property(e => e.QuestionId)
                .HasColumnType("int(11)")
                .HasColumnName("question_id");
            entity.Property(e => e.AnswerA)
                .HasColumnType("text")
                .HasColumnName("answer_a");
            entity.Property(e => e.AnswerB)
                .HasColumnType("text")
                .HasColumnName("answer_b");
            entity.Property(e => e.AnswerC)
                .HasColumnType("text")
                .HasColumnName("answer_c");
            entity.Property(e => e.AnswerD)
                .HasColumnType("text")
                .HasColumnName("answer_d");
            entity.Property(e => e.CorrectAnswer)
                .HasColumnType("text")
                .HasColumnName("correct_answer");
            entity.Property(e => e.GradeId)
                .HasColumnType("int(10)")
                .HasColumnName("grade_id");
            entity.Property(e => e.HuongDan)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("huong_dan");
            entity.Property(e => e.LevelId)
                .HasColumnType("int(12)")
                .HasColumnName("level_id");
            entity.Property(e => e.QuestionContent)
                .HasColumnType("text")
                .HasColumnName("question_content");
            entity.Property(e => e.SentBy)
                .HasMaxLength(255)
                .HasColumnName("sent_by");
            entity.Property(e => e.StatusId)
                .HasColumnType("int(11)")
                .HasColumnName("status_id");
            entity.Property(e => e.SubjectId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("subject_id");
            entity.Property(e => e.Unit)
                .HasColumnType("int(2)")
                .HasColumnName("unit");

            entity.HasOne(d => d.Grade).WithMany(p => p.Questions)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("k9");

            entity.HasOne(d => d.Level).WithMany(p => p.Questions)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("questions_ibfk_1");

            entity.HasOne(d => d.Status).WithMany(p => p.Questions)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("questions_ibfk_2");

            entity.HasOne(d => d.Subject).WithMany(p => p.Questions)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("subjects_key");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("PRIMARY");

            entity.ToTable("rank");

            entity.HasIndex(e => e.RankId, "rank_id");

            entity.Property(e => e.RankId)
                .HasColumnType("int(11)")
                .HasColumnName("rank_id");
            entity.Property(e => e.RankExp)
                .HasColumnType("int(11)")
                .HasColumnName("rank_exp");
            entity.Property(e => e.RankName)
                .HasColumnType("text")
                .HasColumnName("rank_name");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("ranking");

            entity.HasIndex(e => e.RankId, "rank_student");

            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("student_id");
            entity.Property(e => e.Exp)
                .HasColumnType("int(11)")
                .HasColumnName("exp");
            entity.Property(e => e.ExpRemaining)
                .HasColumnType("int(11)")
                .HasColumnName("exp_remaining");
            entity.Property(e => e.RankId)
                .HasColumnType("int(11)")
                .HasColumnName("rank_id");

            entity.HasOne(d => d.Rank).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.RankId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rank_student");

            entity.HasOne(d => d.Student).WithOne(p => p.Ranking)
                .HasForeignKey<Ranking>(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("bfk_id_student");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.TestCode }).HasName("PRIMARY");

            entity.ToTable("scores");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.HasIndex(e => e.TestCode, "test_code");

            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("student_id");
            entity.Property(e => e.TestCode)
                .HasColumnType("int(11)")
                .HasColumnName("test_code");
            entity.Property(e => e.CompletionTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("completion_time");
            entity.Property(e => e.ScoreDetail)
                .HasMaxLength(50)
                .HasColumnName("score_detail");
            entity.Property(e => e.ScoreNumber)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("score_number");

            entity.HasOne(d => d.Student).WithMany(p => p.Scores)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scores_ibfk_1");

            entity.HasOne(d => d.TestCodeNavigation).WithMany(p => p.Scores)
                .HasForeignKey(d => d.TestCode)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("scores_ibfk_2");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("statuses");

            entity.Property(e => e.StatusId)
                .HasColumnType("int(1)")
                .HasColumnName("status_id");
            entity.Property(e => e.Detail)
                .HasMaxLength(50)
                .HasColumnName("detail");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("students");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Permission, "n11");

            entity.HasIndex(e => e.ClassId, "n9");

            entity.HasIndex(e => e.GenderId, "students_gender_id");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("student_id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasDefaultValueSql("'''avatar-default.jpg'''")
                .HasColumnName("avatar");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("class_id");
            entity.Property(e => e.DoingExam)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("doing_exam");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("email");
            entity.Property(e => e.GenderId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("gender_id");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Notification)
                .HasColumnType("int(11)")
                .HasColumnName("notification");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.Permission)
                .HasDefaultValueSql("'3'")
                .HasColumnType("int(1)")
                .HasColumnName("permission");
            entity.Property(e => e.SessionActive)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("session_active");
            entity.Property(e => e.StartingTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("starting_time");
            entity.Property(e => e.TimeRemaining)
                .HasMaxLength(11)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("time_remaining");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("n9");

            entity.HasOne(d => d.Gender).WithMany(p => p.Students)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("students_gender_id");

            entity.HasOne(d => d.PermissionNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Permission)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("n11");
        });

        modelBuilder.Entity<StudentNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student_notifications");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.HasIndex(e => e.NotificationId, "notification_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ClassId)
                .HasColumnType("int(11)")
                .HasColumnName("class_id");
            entity.Property(e => e.NotificationId)
                .HasColumnType("int(11)")
                .HasColumnName("notification_id");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentNotifications)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("student_notifications_ibfk_2");

            entity.HasOne(d => d.Notification).WithMany(p => p.StudentNotifications)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("student_notifications_ibfk_1");
        });

        modelBuilder.Entity<StudentTestDetail>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.TestCode, e.QuestionId }).HasName("PRIMARY");

            entity.ToTable("student_test_detail");

            entity.HasIndex(e => e.TestCode, "fk4");

            entity.HasIndex(e => e.QuestionId, "fk6");

            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("student_id");
            entity.Property(e => e.TestCode)
                .HasColumnType("int(11)")
                .HasColumnName("test_code");
            entity.Property(e => e.QuestionId)
                .HasColumnType("int(11)")
                .HasColumnName("question_id");
            entity.Property(e => e.AnswerA)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("answer_a");
            entity.Property(e => e.AnswerB)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("answer_b");
            entity.Property(e => e.AnswerC)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("answer_c");
            entity.Property(e => e.AnswerD)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("answer_d");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.StudentAnswer)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("student_answer");
            entity.Property(e => e.Timest)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("timest");

            entity.HasOne(d => d.Question).WithMany(p => p.StudentTestDetails)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk6");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentTestDetails)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk9");

            entity.HasOne(d => d.TestCodeNavigation).WithMany(p => p.StudentTestDetails)
                .HasForeignKey(d => d.TestCode)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk4");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PRIMARY");

            entity.ToTable("subjects");

            entity.Property(e => e.SubjectId)
                .HasColumnType("int(11)")
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectDetail)
                .HasMaxLength(255)
                .HasColumnName("subject_detail");
        });

        modelBuilder.Entity<SystemSetting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("PRIMARY");

            entity.ToTable("system_setting");

            entity.HasIndex(e => e.SettingId, "setting").IsUnique();

            entity.Property(e => e.SettingId)
                .HasColumnType("int(11)")
                .HasColumnName("setting_id");
            entity.Property(e => e.Level1A).HasColumnName("level_1_a");
            entity.Property(e => e.Level1B).HasColumnName("level_1_b");
            entity.Property(e => e.Level2A).HasColumnName("level_2_a");
            entity.Property(e => e.Level2B).HasColumnName("level_2_b");
            entity.Property(e => e.Level3A).HasColumnName("level_3_a");
            entity.Property(e => e.Level3B).HasColumnName("level_3_b");
            entity.Property(e => e.Level4A).HasColumnName("level_4_a");
            entity.Property(e => e.Level4B).HasColumnName("level_4_b");
            entity.Property(e => e.QuestTotalAnalysis)
                .HasColumnType("int(11)")
                .HasColumnName("quest_total_analysis");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PRIMARY");

            entity.ToTable("teachers");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Permission, "n2");

            entity.HasIndex(e => e.GenderId, "teachers_gender_id");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.TeacherId)
                .HasColumnType("int(11)")
                .HasColumnName("teacher_id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasDefaultValueSql("'''avatar-default.jpg'''")
                .HasColumnName("avatar");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("email");
            entity.Property(e => e.GenderId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("gender_id");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Notification)
                .HasColumnType("int(11)")
                .HasColumnName("notification");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.Permission)
                .HasDefaultValueSql("'2'")
                .HasColumnType("int(1)")
                .HasColumnName("permission");
            entity.Property(e => e.Username)
                .HasMaxLength(24)
                .HasColumnName("username");

            entity.HasOne(d => d.Gender).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("teachers_gender_id");

            entity.HasOne(d => d.PermissionNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Permission)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("n2");
        });

        modelBuilder.Entity<TeacherNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("teacher_notifications");

            entity.HasIndex(e => e.NotificationId, "notification_id");

            entity.HasIndex(e => e.TeacherId, "teacher_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.NotificationId)
                .HasColumnType("int(11)")
                .HasColumnName("notification_id");
            entity.Property(e => e.TeacherId)
                .HasColumnType("int(11)")
                .HasColumnName("teacher_id");

            entity.HasOne(d => d.Notification).WithMany(p => p.TeacherNotifications)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("teacher_notifications_ibfk_1");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherNotifications)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("teacher_notifications_ibfk_2");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestCode).HasName("PRIMARY");

            entity.ToTable("tests");

            entity.HasIndex(e => e.CreatedBy, "author");

            entity.HasIndex(e => e.SubjectId, "fk1");

            entity.HasIndex(e => e.StatusId, "fk2");

            entity.HasIndex(e => e.GradeId, "grade_id");

            entity.Property(e => e.TestCode)
                .HasColumnType("int(11)")
                .HasColumnName("test_code");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("created_by");
            entity.Property(e => e.GradeId)
                .HasColumnType("int(11)")
                .HasColumnName("grade_id");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("status_id");
            entity.Property(e => e.SubjectId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("subject_id");
            entity.Property(e => e.TestName)
                .HasMaxLength(255)
                .HasColumnName("test_name");
            entity.Property(e => e.TestType)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("test_type");
            entity.Property(e => e.TimeToDo)
                .HasColumnType("int(11)")
                .HasColumnName("time_to_do");
            entity.Property(e => e.Timest)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp")
                .HasColumnName("timest");
            entity.Property(e => e.TotalQuestions)
                .HasColumnType("int(11)")
                .HasColumnName("total_questions");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Tests)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("author");

            entity.HasOne(d => d.Grade).WithMany(p => p.Tests)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("tests_ibfk_1");

            entity.HasOne(d => d.Status).WithMany(p => p.Tests)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk2");

            entity.HasOne(d => d.Subject).WithMany(p => p.Tests)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
