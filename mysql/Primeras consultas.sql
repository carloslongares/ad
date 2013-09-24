SELECT a.id , a.nombre, a.categoria, c.nombre nombre_categoria
FROM articulo a inner join categoria c on a.categoria = c.id;

SELECT a.id , a.nombre, a.categoria, c.nombre nombre_categoria
FROM articulo a left join categoria c on a.categoria = c.id;

SELECT a.id , a.nombre, a.categoria, c.nombre nombre_categoria
FROM articulo a right join categoria c on a.categoria = c.id;

select * from categoria
where id in (select categoria from articulo)
