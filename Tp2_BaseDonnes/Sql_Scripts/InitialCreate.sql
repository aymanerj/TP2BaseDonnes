use master
go
create Database Foot
go
Use Foot
go
exec sp_configure filestream_access_level, 2 reconfigure
alter database Foot 
add filegroup FG_Images_2193774 contains filestream;
go
alter database Foot
add file(
name = FG_Images_2193774,
filename='C:\EspaceLabo\FG_Images_2193774'
)
to filegroup FG_Images_2193774
go