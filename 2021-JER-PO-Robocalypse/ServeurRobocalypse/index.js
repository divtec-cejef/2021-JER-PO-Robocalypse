/* const WebSocket = require('ws')
const wss = new WebSocket.Server({port:8080},()=>{
    console.log('server started')
})

wss.on('connection',(ws)=>{
    ws.on('message', (data)=>{
        console.log('data received %o', data)
        ws.send(data)
    })
})

wss.on('listening',()=>{
    console.log('server is listening on port 8080')
}) */


const express = require('express')
const app = express()
const port = 8080
const path = require('path')

let pret = false;
let etatPartie = "pas commencé";
let arme = "w";
let forme = "f";
let target = "boss";

app.get('/target', (req, res) => {
    res.send(target)
})

app.get('/targetPizza', (req, res) => {
    target = "pizza"
    res.send(target)
})

app.get('/targetCarrot', (req, res) => {
    target = "carrot"
    res.send(target)
})

app.get('/targetBoss', (req, res) => {
    target = "boss"
    res.send(target)
})

app.get('/w', (req, res) => {
    res.send(arme)
})

app.get('/wBlue', (req, res) => {
    arme = "wBlue"
    res.send(arme)
})

app.get('/wRed', (req, res) => {
    arme = "wRed"
    res.send(arme)
})

app.get('/ready', (req, res) => {
    res.send(pret)
})

app.get('/isReady', (req, res) => {
    pret = true
    res.send(pret)
})

app.get('/isNotReady', (req, res) => {
    pret = false
    res.send(pret)
})

app.get('/game', (req, res) => {
    res.send(etatPartie)
})

app.get('/gameIsStarted', (req, res) => {
    etatPartie = "commencé"
    res.send(etatPartie)
})

app.get('/gameIsOver', (req, res) => {
    etatPartie = "fini"
    res.send(etatPartie)
})

app.get('/gameIsWaiting', (req, res) => {
    etatPartie = "pas commencé"
    res.send(etatPartie)
})

/*

app.get('/f', (req, res) => {
    res.send(forme)
})

app.get('/fBallon', (req, res) => {
    forme = "fBallon"
    res.send(forme)
})

app.get('/fAnvil', (req, res) => {
    forme = "fAnvil"
    res.send(forme)
})

app.get('/fHuman', (req, res) => {
    forme = "fHuman"
    res.send(forme)
})

app.get('/wA', (req, res) => {
    arme = "wA"
    res.send(arme)
})

app.get('/wB', (req, res) => {
    arme = "wB"
    res.send(arme)
})

app.get('/w', (req, res) => {
    res.send(arme)
})

app.get('/bA', (req, res) => {
    buff = "bA"
    res.send(buff)
})

app.get('/bB', (req, res) => {
    buff = "bB"
    res.send(buff)
})

app.get('/b', (req, res) => {
    res.send(buff)
})

app.get('/wBlue', (req, res) => {
    arme = "wBlue"
    res.send(arme)
})

app.get('/wYellow', (req, res) => {
    arme = "wYellow"
    res.send(arme)
})

app.get('/wGreen', (req, res) => {
    arme = "wGreen"
    res.send(arme)
})

app.get('/wRed', (req, res) => {
    arme = "wRed"
    res.send(arme)
})

app.get('/w', (req, res) => {
    res.send(arme)
})

app.get('/bJump', (req, res) => {
    buff = "bJump"
    res.send(buff)
})

app.get('/bShield', (req, res) => {
    buff = "bShield"
    res.send(buff)
})

app.get('/bPower', (req, res) => {
    buff = "bPower"
    res.send(buff)
})

app.get('/bSpeed', (req, res) => {
    buff = "bSpeed"
    res.send(buff)
})

app.get('/b', (req, res) => {
    res.send(buff)
})

app.get('/reset', (req, res) => {
    arme = "w";
    buff = "b";
})
*/

app.listen(port, () => {
    console.log(`Le serveur de Robocalypse est lancé et écoute à http://localhost:${port}`)
})
