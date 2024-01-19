Create Table TmpT_DMI855 (



id Int Identity(1,1) ,
TextoArchivo Varchar(5000) not null default (' '),
Referencia Varchar(100) not null default (' '),
FechaCreacion DateTime not null default ('01/01/1900'),
Constraint TmpT_DMI855Key Primary Key  (id) )


Create procedure sp_in_TmpT_DMI855
@TextoArchivo Varchar(5000),
@Referencia Varchar(100)
as
Begin
	Insert into TmpT_DMI855 
	(TextoArchivo,
	Referencia,
	FechaCreacion)
	Values
	(@TextoArchivo,
	@Referencia,
	Getdate())--FechaCreacion
	
End