DECLARE @min_vrijeme time, @max_vrijeme time, @min_datum datetime, @dana int,@brojac int=1
DECLARE @trenutni_datum datetime, @termin_start datetime, @termin_kraj datetime
SELECT @min_vrijeme = MIN(pocetak), @max_vrijeme = MAX(kraj) FROM tRadnoVrijeme 
SELECT @min_datum = MIN(termin_pocetak) FROM tNarudzba 
select @dana = DATEDIFF(DAY,@min_datum ,GETDATE()) from tNarudzba 
select @min_vrijeme, @max_vrijeme, @min_datum, @dana   

--SELECT * FROM tNarudzba 
--where status IN ('Izvrsena','Kreirana')
--ORDER BY termin_pocetak 
select @trenutni_datum = @min_datum 
WHILE @brojac < @dana + 1
begin
select @trenutni_datum 

set @trenutni_datum = DATEADD(DAY,1,@trenutni_datum)
--select @brojac 
set @brojac = @brojac + 1 
end