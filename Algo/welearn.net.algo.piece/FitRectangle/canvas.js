"use strict";

function setupCanvas() {
  const canvas = document.getElementById("myCanvas");
  const ctx = canvas.getContext("2d");
  // Cartesian coordinate system
  ctx.scale(1, -1);
  ctx.translate(0, -canvas.height);
  // margin
  ctx.translate(20.5, 20.5);

  drawAxis(ctx);
  drawAxisNumber(ctx);

  ctx.scale(50, 50);

  return ctx;
}

function setupCanvasForeground(ctx) {
  const ctxForeground = document.getElementById("myCanvasForeground").getContext("2d");
  ctxForeground.setTransform(ctx.getTransform());
  return ctxForeground;
}

function clearAll(context) {
  context.save();
  // Use the identity matrix while clearing the canvas
  context.setTransform(1, 0, 0, 1, 0, 0);
  context.clearRect(0, 0, context.canvas.width, context.canvas.height);
  // Restore the transform
  context.restore();
}

function drawRectFound(ctxForeground, rectFound) {
  for (let i = 0; i < 5; ++i) {
    setTimeout(() => {
      if (i % 2 === 1)
        clearAll(ctxForeground);
      else {
        ctxForeground.fillStyle = "red";
        drawRect(ctxForeground, rectFound);
      }
    }, i * 200)
  }
}

function loadRectStrings(str) {
  return str.map(s => new Rectangle(...(s.split(' '))))
}

function drawAxisNumber(ctx) {
  ctx.save();
  // ctx.scale(1, -1);
  // ctx.translate(-5, 20);
  ctx.transform(1, 0, 0, -1, -5, -20);

  // draw number horizontal
  ctx.font = "18px san-serif";
  let size = ctx.canvas.height - 50;
  for (let i = 0; i < 11; ++i) {
    let x = i * size / 10;
    ctx.fillText(i, x, 0);
  }

  // draw number vertical
  ctx.translate(-15, -15);
  for (let i = 0; i < 11; ++i) {
    let x = i * size / 10;
    ctx.fillText(i, 0, -x);
  }
  ctx.restore();
}

function drawAxis(ctx) {
  ctx.save();
  ctx.globalAlpha = 0.5;
  ctx.setLineDash([1, 4])
  ctx.lineWidth = 1;

  let size = ctx.canvas.height - 50;

  for (let i = 0; i < 11; ++i) {
    let y = i * size / 10;

    // draw horizontal line
    ctx.beginPath();
    ctx.moveTo(0, y);
    ctx.lineTo(size, y);
    ctx.stroke();

    // draw vertical line
    ctx.beginPath();
    ctx.moveTo(y, 0);
    ctx.lineTo(y, size);
    ctx.stroke();
  }
  ctx.restore();
}

function drawRect(ctx, x, y, w, h) {
  if (typeof (x) == 'object') {
    [x, y, w, h] = [x.Left, x.Top, x.Width, x.Height];
  } else if (y === undefined) {
    let p = x.split(' ');
    [x, y, w, h] = [p[0], p[1], p[2], p[3]];
  }
  ctx.save();
  ctx.globalAlpha = 0.3;
  ctx.translate(x, y);
  ctx.scale(1, -1);
  ctx.fillRect(0, 0, w, h);
  ctx.restore();
}

async function drawBlinkRectAsync(ctx, rect) {
  ctx.fillStyle = "yellow";
  for (let i = 0; i < 5; ++i) {
    drawRect(ctx, rect);
    await sleep(200);
    clearAll(ctx);
  }
  drawRect(ctx, rect);
}