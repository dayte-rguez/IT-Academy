SELECT count(*) as 'Total de vuelos' 
FROM flights;
SELECT Origin as Aeropuerto, AVG(ArrDelay) as 'Promedio retraso llegadas', AVG(DepDelay) as 'Promedio retraso salidas' 
FROM `flights` 
GROUP BY Origin;
SELECT Origin as Aeropuerto, AVG(ArrDelay) as 'Promedio retraso llegadas' 
FROM `flights` 
GROUP BY Origin;
SELECT Origin as Aeropuerto, colYear,colMonth, AVG(ArrDelay) as 'Promedio retraso llegadas' 
FROM `flights` 
GROUP BY colYear, colMonth, Origin
ORDER BY Origin ASC, colYear ASC, colMonth ASC;
SELECT usairports.City, colYear,colMonth, AVG(ArrDelay) as 'Promedio retraso llegadas' 
FROM `flights`
LEFT JOIN usairports on flights.Origin = usairports.IATA
GROUP BY colYear, colMonth, Origin
ORDER BY Origin ASC, colYear ASC, colMonth ASC;
SELECT UniqueCarrier, colYear,colMonth, COUNT(Cancelled) as Total_cancelled  
FROM `flights`
WHERE Cancelled = 1
GROUP BY UniqueCarrier, colYear, colMonth 
ORDER by Total_cancelled DESC;
SELECT TailNum, SUM(Distance) as totalDistance
FROM `flights`
WHERE TailNum != ''
GROUP BY TailNum
ORDER BY totalDistance DESC
LIMIT 10;
SELECT UniqueCarrier, AVG(ArrDelay) as avgDelay
FROM `flights`
GROUP BY UniqueCarrier
HAVING avgDelay > 10;



