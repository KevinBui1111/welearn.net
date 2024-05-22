"use strict";

function setupCanvas(name, wUnit, hUnit) {
  const canvas = document.getElementById(name);
  const ctx = canvas.getContext("2d");
  // Cartesian coordinate system
  ctx.scale(1, -1);
  ctx.translate(0, -canvas.height);
  // margin
  ctx.translate(20.5, 20.5);

  let [w, h] = [canvas.width - 50, canvas.height - 50];
  drawAxis(ctx, wUnit, hUnit, w, h);
  drawAxisNumber(ctx, wUnit, hUnit, w, h);

  ctx.scale(w / wUnit, h / hUnit);

  return ctx;
}

function setupCanvasForeground(name, ctx) {
  const ctxForeground = document.getElementById(name).getContext("2d");
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

function drawAxisNumber(ctx, wUnit, hUnit, w, h) {
  ctx.save();
  // ctx.scale(1, -1);
  // ctx.translate(-5, 20);
  ctx.transform(1, 0, 0, -1, -5, -20);

  // draw number horizontal
  ctx.font = "18px san-serif";
  for (let i = 0; i <= w; ++i) {
    let x = i * w / wUnit;
    ctx.fillText(i, x, 0);
  }

  // draw number vertical
  ctx.translate(-15, -15);
  for (let i = 0; i <= h; ++i) {
    let x = i * h / hUnit;
    ctx.fillText(i, 0, -x);
  }
  ctx.restore();
}

function drawAxis(ctx, wUnit, hUnit, w, h) {
  ctx.save();
  ctx.globalAlpha = 0.5;
  ctx.setLineDash([1, 4])
  ctx.lineWidth = 1;
  
  [...Array(h + 1)].forEach((_, i) => {
    let y = i * h / hUnit;

    // draw horizontal line
    ctx.beginPath();
    ctx.moveTo(0, y);
    ctx.lineTo(w, y);
    ctx.stroke();
  });

  [...Array(w + 1)].forEach((_, i) => {
    let y = i * w / wUnit;
    // draw vertical line
    ctx.beginPath();
    ctx.moveTo(y, 0);
    ctx.lineTo(y, h);
    ctx.stroke();
  });
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
  if (!rect.Width) return;

  clearAll(ctx);
  ctx.fillStyle = "yellow";
  for (let i = 0; i < 1; ++i) {
    drawRect(ctx, rect);
    await sleep(400);
    clearAll(ctx);
    await sleep(100);
  }
  drawRect(ctx, rect);
}