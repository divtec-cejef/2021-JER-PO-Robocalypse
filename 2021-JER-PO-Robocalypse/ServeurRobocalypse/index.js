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
let forme = "f";
let arme = "w";

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
/*
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
    console.log(`Example app listening at http://localhost:${port}`)
})
