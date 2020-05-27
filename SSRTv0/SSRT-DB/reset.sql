set sql_safe_updates=0;
delete from publication;
delete from query;
delete from queryconverter;
alter table query auto_increment=1;
alter table publication auto_increment=1;
alter table queryconverter auto_increment=1;