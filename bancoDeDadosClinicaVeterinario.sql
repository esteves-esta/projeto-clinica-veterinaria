create database bdClinicaVet0309
use bdClinicaVet0309

create table tbResponsavel(
CodResp int Primary Key,
NomeResp varchar (50),
EndResp varchar (50),
BairroResp varchar (50),
CidadeResp varchar (50),
estadosResp varchar (2)
)

Create table tbTipoAnimal(
CodTipo int Primary Key,
TipoAnimal varchar (50)
)

Create table tbRacaAnimal(
CodRaca int Primary Key,
RacaAnimal varchar (50)
)

Create table tbAnimal(
CodAnimal int Primary Key,
NomeAnimal  varchar (50),
CodTipo int references tbTipoAnimal(CodTipo),
CodRaca int references tbRacaAnimal(CodRaca),
CodResp int references tbResponsavel (CodResp),
DataCadastro varchar (50)
)

--CONSULTA TIPO RACA
create procedure pa_consultaRaca
as begin
	select CodRaca as [Código], RacaAnimal as [Raça] from tbRacaAnimal
end

exec pa_consultaRaca


--PESQUISA TIPO RACA
create procedure pa_pesquisaRaca
@raca varchar(50)
as begin
	select CodRaca as [Código], RacaAnimal as [Raça] from tbRacaAnimal
	where RacaAnimal like '%' + @raca + '%'
end

exec pa_pesquisaRaca 'sia'

--INSERIR TIPO RACA
create procedure pa_inserirRaca
@cod int,
@raca varchar(50)
as begin
	insert into tbRacaAnimal values(@cod, @raca)
end

exec pa_inserirRaca 3, 'pug'

--CONSULTA TIPO RESPONSAVEL
create procedure pa_consultaResponsavel
as begin
	select CodResp as [Código], NomeResp as Nome, EndResp as [Endereço], BairroResp as Bairro, CidadeResp as Cidade, estadosResp as [UF] 
	from tbResponsavel
end

exec pa_consultaResponsavel

--PESQUISA TIPO RESPONSAVEL
create procedure pa_pesquisaResponsavel
@nome varchar(50)
as begin
	select CodResp as [Código], NomeResp as Nome, EndResp as [Endereço], BairroResp as Bairro, CidadeResp as Cidade, estadosResp as [UF] 
	from tbResponsavel
	where NomeResp like '%' + @nome + '%' 
end

exec pa_pesquisaResponsavel 'Fer'

--INSERIR TIPO RESPONSAVEL
create procedure pa_inserirResponsavel
@cod int,
@nome varchar(50),
@end varchar(50),
@bairro varchar(50),
@cid varchar(50),
@uf varchar(2)
as begin
	insert into tbResponsavel values (@cod, @nome, @end, @bairro, @cid, @uf)
end

exec pa_inserirResponsavel 2, 'Claudia', 'Rua dos Guaicacas', 'Morro', 'São Paulo', 'SP'

--CONSULTA TIPOANIMAL
create procedure pa_consultaTipo
as begin
	select CodTipo as [Código], TipoAnimal as [Tipo do Animal] from tbTipoAnimal
end

exec pa_consultaTipo

--PESQUISAR TIPOANIMAL
create procedure pa_pesquisaTipo
@cod int
as begin
	select CodTipo as [Código], TipoAnimal as [Tipo do Animal] from tbTipoAnimal
	where CodTipo = @cod
end

exec pa_pesquisaTipo 3

--INSERIR TIPOANIMAL
create procedure pa_inserirTipo
@cod int, @tipo varchar(50)
as begin
	insert into tbTipoAnimal values(@cod, @tipo)
end

exec pa_inserirTipo 4, 'Tartaruga' 


--CONSULTA ANIMAL
create procedure pa_consultaAnimal
as begin
	select a.CodAnimal as [Código do Pet], a.NomeAnimal as [Nome do Pet], 
	t.TipoAnimal as [Tipo do Animal] ,r.RacaAnimal as [Raca], res.NomeResp as [Responsável]
	from tbAnimal as a 
	inner join tbTipoAnimal as t
	on t.CodTipo = a.CodTipo
	inner join tbRacaAnimal as r
	on r.CodRaca = a.CodRaca
	inner join tbResponsavel as res
	on res.CodResp = a.CodResp
end

exec pa_consultaAnimal


--PESQUISA ANIMAL
create procedure pa_pesquisaAnimal
@nomea varchar(50)
as begin
	select a.CodAnimal as [Código do Pet], a.NomeAnimal as [Nome do Pet], 
	t.TipoAnimal as [Tipo do Animal] ,r.RacaAnimal as [Raca], res.NomeResp as [Responsável]
	from tbAnimal as a 
	inner join tbTipoAnimal as t
	on t.CodTipo = a.CodTipo
	inner join tbRacaAnimal as r
	on r.CodRaca = a.CodRaca
	inner join tbResponsavel as res
	on res.CodResp = a.CodResp
	where NomeAnimal like '%' + @nomea + '%'
end

exec pa_pesquisaAnimal 'Seba'


--INSERIR ANIMAL
create procedure pa_inserirAnimal
@coda int, @nomepet varchar(50), @codraca int, @codresp int, @codtipo int, @data varchar(50)
as begin
	insert into tbAnimal values(@coda, @nomepet, @codraca, @codresp, @codtipo, @data)
end

exec pa_inserirAnimal 3, 'Marshmellow', 1, 3, 1, '2018-09-06'


